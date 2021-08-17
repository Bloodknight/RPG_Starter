
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Functions for AFX Demo
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// demo spellbook management

$Book_Max_Spells = 12*12;
$Book_First_User_Slot = 3*12; // set to 0 for AFXDemo Lite Template

function loadDemoSpellbook(%book)
{
  for (%i = 0; %i < $Book_Max_Spells; %i++)
  {
    if ($Book_Rpg[%i] !$= "")
    {
      %book.rpgSpells[%i] = $Book_Rpg[%i];
      %book.spells[%i] = $Book_Rpg[%i].spellFXData;
    }
  }

  deleteVariables("$Book_Rpg*");
}

function clearDemoSpellbookData()
{
  deleteVariables("$Book_PageNames*");
}

function setDemoSpellbookBankName(%page, %name)
{
  $Book_PageNames[%page] = %name;
}

function addDemoSpellbookPlaceholder(%placeholder, %page, %slot)
{
  if (%placeholder.getClassName() !$= "afxRPGMagicSpellData")
    return;

  %placeholder.isPlaceholder = true;

  %idx = %page*12 + %slot;
  if (%idx >= 0 && %idx < $Book_Max_Spells)
  {
    $Book_Rpg[%idx] = %placeholder;
  }
}

function addDemoSpellbookSpell(%spell_db, %rpg_db)
{
  if (!isObject(%spell_db) || !isObject(%rpg_db))
    return;

  %spell_name = %rpg_db.spellName;
  if (%spell_name $= "")
    return;

  // find a placeholder with a matching name
  %idx = -1;
  %cap = 12*12;
  for (%i = 0; %i  < $Book_Max_Spells; %i++)
  {
    if ($Book_Rpg[%i] !$= "" && $Book_Rpg[%i].spellName $= %spell_name && $Book_Rpg[%i].isPlaceholder)
    {
      %idx = %i;
      break;
    }
  }

  // if placeholder was found, replace it
  if (%idx >= 0)
  {
    $Book_Rpg[%idx] = %rpg_db;
    %rpg_db.spellFXData = %spell_db;
    return;
  }

  // if no placeholder was found, use first empty slot
  // beginning with 4th spellbank.
  %idx = -1;
  for (%i = $Book_First_User_Slot; %i  < $Book_Max_Spells; %i++)
  {
    if ($Book_Rpg[%i] $= "")
    {
      %idx = %i;
      break;
    }
  }

  // if empty slot was found, insert spell there
  if (%idx >= 0)
  {
    $Book_Rpg[%idx] = %rpg_db;
    %rpg_db.spellFXData = %spell_db;
    return;
  }

  error("Demo Spellbook is full. Cannot add spell, \"" @ %spell_name @ "\".");
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// demo selectron management

$Total_Sele_Styles = 0;
$Sele_Style_Names[0] = "";
$Sele_Style_Ids[0] = "";

function resetDemoSelectronStyles()
{
  $Total_Sele_Styles = 0;
}

function addDemoSelectronStyle(%sele_name, %sele_id)
{
  $Sele_Style_Names[$Total_Sele_Styles] = %sele_name;
  $Sele_Style_Ids[$Total_Sele_Styles] = %sele_id;
  $Total_Sele_Styles++;
}

function serverCmdNextSelectronStyle(%client, %current_style, %do_prev, %display_msg)
{
  %idx = -1;
  for (%i = 0; %i < $Total_Sele_Styles; %i++)
  {
    if (%current_style == $Sele_Style_Ids[%i])
    {
      %idx = %i;
      break;
    }
  }

  if (%idx == -1)
  {
    if ($Total_Sele_Styles == 0)
      return;
    %idx = (%do_prev) ? 0 : $Total_Sele_Styles;
  }


  if (%do_prev)
  {
    if (%idx == 0)
      %idx = $Total_Sele_Styles;
    %idx--;
  }
  else
  {
    %idx++;
    if (%idx >= $Total_Sele_Styles)
      %idx = 0;
  }

  commandToClient(%client, 'UpdateSelectronStyle', $Sele_Style_Names[%idx], $Sele_Style_Ids[%idx], %display_msg);
}

function serverCmdSetSelectronStyle(%client, %style_name, %display_msg)
{
  %idx = -1;
  for (%i = 0; %i < $Total_Sele_Styles; %i++)
  {
    if (%style_name $= $Sele_Style_Names[%i])
    {
      %idx = %i;
      break;
    }
  }

  if (%idx == -1)
  {
    if ($Total_Sele_Styles == 0)
      return;
    %idx = 0;
  }

  commandToClient(%client, 'UpdateSelectronStyle', $Sele_Style_Names[%idx], $Sele_Style_Ids[%idx], %display_msg);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//

// demo sci-fi mode

function enableSciFiMode(%client)
{
  if (%client.player != 0)
  {
    echo("Enable Sci-Fi Mode");
    if (isFunction(equipSciFiOrc))
      equipSciFiOrc(%client.player);
    serverCmdSetSelectronStyle(%client, "SCI-FI", false);
  }
}

function disableSciFiMode(%client)
{
  if (%client.player != 0)
  {
    echo("Disable Sci-Fi Mode");
    if (isFunction(unequipSciFiOrc))
      unequipSciFiOrc(%client.player);
    serverCmdSetSelectronStyle(%client, "AFX Default", false);
  }
}

function serverCmdOnSpellbankChange(%client, %old_bank, %new_bank)
{
  %spellbook = afxDemoSpellBookData;

  if (!isObject(%spellbook))
  {
    error("serverCommand('onSpellbankChange'): failed to find spellbook.");
    return;
  }


  if ($Book_PageNames[%new_bank] !$= "")
    commandToClient(%client, 'DisplayScreenMessage', $Book_PageNames[%new_bank], clear);
  else
    commandToClient(%client, 'DisplayScreenMessage', "Spellbank" SPC %new_bank, clear);

  if ($Book_PageNames[%old_bank] $= "SCI-FI Mode")
    disableSciFiMode(%client);

  if ($Book_PageNames[%new_bank] $= "SCI-FI Mode")
    enableSciFiMode(%client);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//

function GameConnection::onDeathAFX(%this, %sourceObject, %sourceClient, %damageType, %damLoc)
{
  // clear connections camera
  %this.clearCameraObject();

  if (isObject(%this.player))
  {
    %corpse = %this.player;

    // interrupt active spellcasting
    if (isObject(%corpse.spellBeingCast))
    {
      %spell = %corpse.spellBeingCast;
      %corpse.spellBeingCast = "";
      %spell.interrupt();
    }

    // clear out the name on the corpse
    %corpse.setShapeName("Dead Orc");
    schedule(1000, 0, afxBroadcastTargetStatusbarReset);

    // zero out energy level
    %corpse.setEnergyLevel(0);

    // switch the client over to the death cam and unhook the player object.
    if (isObject(%this.camera))
    {
      %this.camera.setOrbitMode(%corpse, %corpse.getTransform(), 0.5, 4.5, 4.5);
      %this.setControlObject(%this.camera);
    }
  }

  // Dole out points and display an appropriate message
  if (%damageType $= "Suicide" || %sourceClient == %this)
  {
    %this.incScore(-1);
    messageAll('MsgClientKilled', '%1 takes his own life!', %this.name);
  }
  //UAISK+AFX Interop Changes: Start
  else if ($UAISK_Is_Available)
  {
    //If the killer was a bot, don't try to get its name
    if (%sourceClient !$= "")
    {
      //Only give points for killing the other team
      if (%sourceClient.team == %this.team)
        %sourceClient.incScore(-1);
      else
        %sourceClient.incScore(1);

      messageAll('MsgClientKilled','%1 gets nailed by %2!',%this.name,%sourceClient.name);
    }
    else
      messageAll('MsgClientKilled','%1 gets nailed by a bot!',%this.name);

    if (%sourceClient.score >= $Game::EndGameScore)
      cycleGame();
  }
  //UAISK+AFX Interop Changes: End
  else if (%sourceClient !$= "") //AFX Patch Update
  {
    %sourceClient.incScore(1);
    messageAll('MsgClientKilled', '%1 gets nailed by %2!', %this.name, %sourceClient.name);
    if (%sourceClient.score >= $Game::EndGameScore)
      cycleGame();
  }
}

function afxBroadcastTargetStatusbarReset()
{
  %count = ClientGroup.getCount();
  for (%i = 0; %i < %count; %i++)
  {
    %cl = ClientGroup.getObject(%i);
    if( !%cl.isAIControlled() )
      commandToClient(%cl, 'ResetTargetStatusbarLabel');
  }
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//

$afxPickTeleportDest_Tries = 0;

function afxPickTeleportDest(%current_pos)
{ 
  %dist = 0;
  %n_tries = 0;

  while (%dist < 15 && %n_tries < 5)
  {
    %spawnPoint = pickPlayerSpawnPoint("MissionGroup/TeleportSpots");

    // if %spawnPoint is an object, grab it's transform
    if (getWordCount(%spawnPoint) == 1 && isObject(%spawnPoint))
      %teleport_loc = %spawnPoint.getTransform();
    else // otherwise assume it's a transform or point
      %teleport_loc = %spawnPoint;

    %dist = VectorDist(%current_pos, %teleport_loc);
    %n_tries++;
  }

  return %teleport_loc;
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//

function afxBurnCorpse(%corpse)
{
  if (isObject(%corpse) && %corpse.getClassName() $= "Player")
  {
    // fade and delete corpse
    %corpse.schedule(0, "startFade", 1000, 0, true);
    %corpse.schedule(1000+1000, "delete");

    // if player is still associated with corpse, spawn a new one
    if (isObject(%corpse.client) && %corpse.client.player == %corpse)
    {
      %corpse.client.schedule(2000, "spawnPlayer", pickPlayerSpawnPoint($Game::DefaultPlayerSpawnGroups));
      %corpse.client.player = "";
      %corpse.client = "";
    }

    return;
  }

  //UAISK+AFX Interop Changes: Start
  if ($UAISK_Is_Available)
  {
    if (%corpse.isbot)
      %corpse.burnCorpse(%corpse);
  }
  //UAISK+AFX Interop Changes: End
  
  // let NonPlayerWrangler handle this corpse burning
  if (isObject(NonPlayerWrangler))
    NonPlayerWrangler.burnCorpse(%corpse);
}

function afxResurrectCorpse(%corpse)
{
  if (isObject(%corpse) && %corpse.getClassName() $= "Player")
  {
    // if player is still associated with corpse, spawn a new one
    if (isObject(%corpse.client) && %corpse.client.player == %corpse)
    {
      %corpse.client.schedule(250, "spawnPlayer", %corpse.getTransform(), "Player", %corpse.getDatablock());
      %corpse.client.player = "";
      %corpse.client = "";
    }

    // fade and delete corpse 
    %corpse.schedule(0, "startFade", 500, 0, true);
    %corpse.schedule(500, "delete");

    return;
  }

  //UAISK+AFX Interop Changes: Start
  if ($UAISK_Is_Available)
  {
    if (%corpse.isbot)
      %corpse.resurrectCorpse(%corpse);
  }
  //UAISK+AFX Interop Changes: End
  
  // let NonPlayerWrangler handle this resurrection
  if (isObject(NonPlayerWrangler))
    NonPlayerWrangler.resurrectCorpse(%corpse);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
