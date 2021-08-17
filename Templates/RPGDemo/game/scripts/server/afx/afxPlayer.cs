
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Functions for AFX Demo
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

//UAISK+AFX Interop Changes: Start
if ($UAISK_Is_Available)
   exec("data/Cogflicts/scripts/server/UAISK/aiDatablocks.cs");
//UAISK+AFX Interop Changes: End

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

function PlayerDataAFX::onAdd(%this,%obj)
{
   // Vehicle timeout
   %obj.mountVehicle = true;

   // Default dynamic armor stats
   %obj.setRechargeRate(%this.rechargeRate);
   %obj.setRepairRate(%this.repairRate);

   //UAISK+AFX Interop Changes: Start
   if ($UAISK_Is_Available && isObject(%obj.client))
   {
      %client = %obj.client;

      //Give the client and player a team
      if (%client.team $= "")
         %client.team = 1;

      %obj.team = %client.team;

      //Put the player in a SimSet with its teammates
      TeamSimSets(%obj, %obj.team);
   }
   //UAISK+AFX Interop Changes: End
}

function PlayerDataAFX::onRemove(%this, %obj)
{
  if (isFunction(unequipSciFiOrc))
    unequipSciFiOrc(%obj);

  if (isObject(%obj.lingering_spell))
  {
    %obj.lingering_spell.interrupt();
    %obj.lingering_spell = "";
  }

  if (%obj.client.player == %obj)
    %obj.client.player = 0;
}

//~~~~~~~~~~~~~~~~~~~~//

function PlayerDataAFX::onCollision(%this,%obj,%col)
{
   if (%obj.getState() $= "Dead")
      return;

   //UAISK+AFX Interop Changes: Start
   //If this is a bot that collided with an enemy, face that enemy
   if ($UAISK_Is_Available && %obj.isbot == true)
   {
      if (%col.team != %obj.team && %col.team !$= "" && !%obj.specialMove)
      {
         //If the bot is skittish, have it run away
         if (%obj.behavior.isSkittish)
            %obj.sidestep(%obj);

         if (%obj.getAimObject() <= 0)
         {
            if (!%obj.behavior.isSkittish)
               %obj.setAimObject(%col, $AISK_CHAR_HEIGHT);

            if (%obj.behavior.isAggressive)
               %obj.ailoop = %obj.schedule($AISK_QUICK_THINK, "Think", %obj);
         }
      }
   }
   //UAISK+AFX Interop Changes: End

    // Try and pickup all items
    if (%col.getClassName() $= "Item")
    {
        %obj.pickup(%col);
        return;
    }


    // Mount vehicles
    if (%col.getType() & $TypeMasks::GameBaseObjectType)
    {
        %db = %col.getDataBlock();
        if ((%db.getClassName() $= "WheeledVehicleData") && %obj.mountVehicle && %obj.getState() $= "Move" && %col.mountable)
        {
            // Only mount drivers for now.
            %node = 0;
            %col.mountObject(%obj, %node);
            %obj.mVehicle = %col;
        }
    }
}

function PlayerDataAFX::onImpact(%this, %obj, %collidedObject, %vec, %vecLen)
{
   %obj.damage(0, VectorAdd(%obj.getPosition(),%vec),
      %vecLen * %this.speedDamageScale, "Impact");
}

//~~~~~~~~~~~~~~~~~~~~//

function PlayerDataAFX::damage(%this, %obj, %sourceObject, %position, %damage, %damageType)
{
   if (%obj.getState() $= "Dead")
      return;

   //UAISK+AFX Interop Changes: Start
   if ($UAISK_Is_Available)
   {
      //If friendly fire is turned off, and the source and target are on
      //the same team, then return
      if ($AISK_FRIENDLY_FIRE == false && $AISK_FREE_FOR_ALL == false)
      {
         if (%sourceObject.getClassName() !$= "afxMagicSpell")
         {
            if (%sourceObject.sourceObject.team == %obj.team)
               return;
         }
         else if (%sourceObject.caster.team == %obj.team)
            return;
      }

      //If this is a bot, set its attention level
      if (%obj.isbot == true)
      {
         //Move a little when hit, aggressive bots move in the "Defending" state
         if (!%obj.behavior.isAggressive)
            %obj.sidestep(%obj, true);
         else if (!%obj.specialMove)
         {
            //Item gathering has been commented out because it does not work properly
            //if (%obj.action !$= "GetHealth")
            //{
            //If the bot got sniped, enhance its vision
            if (%obj.action !$= "Attacking" && %obj.action !$= "Defending" && %obj.getstate() !$= "Dead")
            {
               %obj.enhancedefending(%obj);
               %obj.attentionlevel = 1;
               %obj.ailoop = %obj.schedule($AISK_QUICK_THINK, "Think", %obj);
            }

            %obj.action = "Defending";
            //}
         }

         //Don't hurt unkillable bots
         if (!%obj.behavior.isKillable)
            return;
      }
   }
   //UAISK+AFX Interop Changes: End

   // setting damage-level directly allows negative damage for healing
   %obj.setDamageLevel(%obj.getDamageLevel() + %damage);

   %location = "Body";

   // handle possible spell interruption due to damage
   afxTestSpellcastingDamageInterruption(%obj, %damage, %damageType);

   // Deal with client callbacks here because we don't have this
   // information in the onDamage or onDisable methods
   %client = %obj.client;
   %sourceClient = %sourceObject ? %sourceObject.client : 0;

   //UAISK+AFX Interop Changes: Start
   //Have other bots assist the injured if needed
   if ($UAISK_Is_Available)
      checkAboutAssisting(%obj);
   //UAISK+AFX Interop Changes: End

   if (%obj.getState() $= "Dead")
   {
     %obj.setShapeName("Dead Orc");
     %obj.setRepairRate(0);
     %obj.setEnergyLevel(0);
     %obj.setRechargeRate(0);

      //UAISK+AFX Interop Changes: Start
      if ($UAISK_Is_Available && %obj.isbot == true)
      {
         // interrupt active spellcasting
         if (isObject(%obj.spellBeingCast))
         {
            %spell = %obj.spellBeingCast;
            %obj.spellBeingCast = "";
            %spell.interrupt();
         }

         %marker = %obj.marker;

         //Check if the bots should still be respawning
         if (%marker.respawnCount > 0)
         {
            if (%marker.respawnCounter <= 0)
               %obj.respawn = false;

            %marker.respawnCounter--;
         }

         //Respawn the bot if needed
         if (%obj.respawn == true)
         {
            %marker.delayRespawn = schedule($AISK_RESPAWN_DELAY, %marker, "AIPlayer::spawn", %marker, true);
            %this.player = 0;
         }
         else
         {
            %marker.botBelongsToMe = "";
            %marker.respawnCount = "";
            %marker.respawnCounter = "";
         }
      }
      else if (isObject(%client))
         %client.onDeathAFX(%sourceObject, %sourceClient, %damageType, %location);
      //UAISK+AFX Interop Changes: End
   }
}

function PlayerDataAFX::onDamage(%this, %obj, %delta)
{
    // If flying_damage_text.cs is loaded, displayFlyingDamageText() exists
    // and we call it to have the damage amount shown as an effect.
    if (%delta >= 1 && isFunction(displayFlyingDamageText))
      displayFlyingDamageText(%obj, mFloor(%delta));

   // This method is invoked by the ShapeBase code whenever the
   // object's damage level changes.
   if (%delta > 0 && %obj.getState() !$= "Dead") {

      // Increment the flash based on the amount.
      %flash = %obj.getDamageFlash() + ((%delta / %this.maxDamage) * 2);
      if (%flash > 0.75)
         %flash = 0.75;
      %obj.setDamageFlash(%flash);

      // If the pain is excessive, let's hear about it.
      if (%delta > 10)
         %obj.playPain();
   }
}

function PlayerDataAFX::onDisabled(%this,%obj,%state)
{
   // The player object sets the "disabled" state when damage exceeds
   // it's maxDamage value.  This is method is invoked by ShapeBase
   // state mangement code.

   // If we want to deal with the damage information that actually
   // caused this death, then we would have to move this code into
   // the script "damage" method.
   %obj.playDeathCry();
   %obj.playDeathAnimation();
   %obj.setDamageFlash(0.75);

   // Release the main weapon trigger
   %obj.setImageTrigger(0,false);

   // Unlike the default onDisabled(), we don't do any
   // automatic corpse disposal.
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

