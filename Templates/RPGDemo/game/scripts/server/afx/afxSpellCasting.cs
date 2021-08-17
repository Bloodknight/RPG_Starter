 
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
//  afxPerformSpellbookCast()
//
//    Used to cast spells from the player's spellbook.
//    Used by the spellbank gui to cast spells
//
function afxPerformSpellbookCast(%caster, %book_slot, %target, %client)
{
  %spell_game_data = %client.spellbook.getSpellRPGData(%book_slot);
  if (!isObject(%spell_game_data))
  {
    DisplayScreenMessage(%client, "Failed to find spell definition in spellbook. (casting)");
    return;
  }

  %spell_data = %spell_game_data.spellFXData;
  if (!isObject(%spell_data))
  {
    DisplayScreenMessage(%client, "Failed to find spell effects in spellbook. (casting)");
    return;
  }

  afxPerformSpellCast(%caster, %spell_game_data, %target, %client, "");
}

function afxPerformFreeTargetingSpellbookCast(%caster, %book_slot, %free_target, %client)
{
  %spell_game_data = %client.spellbook.getSpellRPGData(%book_slot);
  if (!isObject(%spell_game_data))
  {
    DisplayScreenMessage(%client, "Failed to find spell definition in spellbook. (casting)");
    return;
  }

  %spell_data = %spell_game_data.spellFXData;
  if (!isObject(%spell_data))
  {
    DisplayScreenMessage(%client, "Failed to find spell effects in spellbook. (casting)");
    return;
  }

  if (%free_target $= "")
  {
    DisplayScreenMessage(%client, "Invalid target location.");
    return;
  }

  afxPerformSpellCast(%caster, %spell_game_data, "", %client, %free_target);
}

// Note - Players and NPCs can cast spells using afxPerformSpellCast(). 
// When used to cast an NPC spell, leave off the %client argument
// or pass a value of "". This prevents message display.
function afxPerformSpellCast(%caster, %spell_data, %target, %client, %free_target)
{
  if (!isObject(%spell_data) || %spell_data.getClassName() !$= "afxRPGMagicSpellData")
  {
    DisplayScreenMessage(%client, "Invalid spell definition.");
    return;
  }

  %rpg_data = %spell_data;
  %spell_data = %rpg_data.spellFXData;

  // test if caster exists
  if (!isObject(%caster))
  {
    DisplayScreenMessage(%client, "This client has no spellcaster.");
    return;
  }
 
  // test if caster is alive (enabled)
  if (!%caster.isEnabled())
  {
    DisplayScreenMessage(%client, "You're dead.");
    return;
  }

  // test is caster is already casting a spell
  if (isObject(%caster.spellBeingCast))
  {
    DisplayScreenMessage(%client, "Already casting another spell.");
    return;
  }

  // test is caster is anim-locked
  if (%caster.isAnimationLocked())
  {
    DisplayScreenMessage(%client, "You're unable to concentrate.");
    return;
  }

  if (!isObject(%rpg_data))
  {
    DisplayScreenMessage(%client, "Failed to find RPG spell definition.");
    return;
  }

  %mana_cost = %rpg_data.manaCost;
  %mana_pool = %caster.getEnergyLevel();

  // test if caster has enough mana
  if (%mana_pool < %mana_cost)
  {
    DisplayScreenMessage(%client, "Not enough mana.");
    return;
  }

  %tgt = %rpg_data.target;

  // clear superfluous target 
  if ((%tgt $= "nothing" || %tgt $= "free") && !%rpg_data.targetOptional)
    %target = 0;

  // test if free target is required
  if (%free_target $= "" && %tgt $= "free")
  {
    DisplayScreenMessage(%client, "Spell requires a freely positioned target.");
    return;
  }

  // test if target is required
  if (!isObject(%target) && !%rpg_data.targetOptional)
  {
    if (%tgt $= "enemy" || %tgt $= "corpse" || %tgt $= "friend")
    {
      DisplayScreenMessage(%client, "Spell requires a target.");
      return;
    }
  }

  // validate target
  if (isObject(%target))
  {
    // make sure corpse targets are really dead 
    if (%tgt $= "corpse" && %target.isEnabled())
    {
      DisplayScreenMessage(%client, "Try targeting something that's dead.");
      return;
    }

    // make sure targeting self is allowed 
    if (%target $= %caster && %tgt !$= "self" && !%rpg_data.canTargetSelf)
    {
      DisplayScreenMessage(%client, "Casting this spell on yourself is not good idea.");
      return;
    }

    // check range
    if (%rpg_data.range > 0)
    {
      %target_dist = VectorDist(%caster.getWorldBoxCenter(), %target.getWorldBoxCenter());
      if (%target_dist > %rpg_data.range)
      {
        DisplayScreenMessage(%client, "Target is out of range.");
        return;
      }
    }
  }

  // self-targeting
  if (%tgt $= "self")
    %target = %caster;

  // spell datablock gets last chance to find reasons to fizzle
  if (!%spell_data.readyToCast(%caster, %target))
    return;

  if (%caster.replaceSpellTarget !$= "")
  {
     %target = %caster.replaceSpellTarget;
     %caster.replaceSpellTarget = "";
  }

  if (isObject(%client)) // for cooldown display 
    %caster.activeSpellbook = %client.spellbook;
   
  %spell = castSpell(%spell_data, %caster, %target, %rpg_data);
  if (%free_target !$= "")
  {
    %spell.addConstraint(%free_target, "freeTarget");
    %spell.freeTarget = %free_target;
  }
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
//  Default script methods called from afxMagicSpell


function afxMagicSpellData::onActivate(%this, %spell, %caster, %target)
{
  //echo("Default afxMagicSpellData::onActivate()");

  // attach active spell to caster. this prevent overlapping casts.
  if (%caster.spellBeingCast $= "")
    %caster.spellBeingCast = %spell;

  // save mana recharge-rate, then set to zero while casting
  //%caster.rechargeRate_saved = %caster.getRechargeRate();
  %caster.setRechargeRate(0.0);

  // initiate global cooldown on spellbook
  if (isObject(%caster.activeSpellbook))
    %caster.activeSpellbook.startAllSpellCooldown();
}

function afxMagicSpellData::onLaunch(%this, %spell, %caster, %target, %missile)
{
  if (!isObject(%caster))
    return false;

  if (%caster.spellBeingCast == %spell)
    %caster.spellBeingCast = "";

  %caster.setRechargeRate(%caster.getDataBlock().rechargeRate);

  %rpg_data = %spell.extra;
  if (isObject(%rpg_data))
  {
    %mana_cost = %rpg_data.manaCost;
    %mana_pool = %caster.getEnergyLevel();
    %caster.setEnergyLevel(%mana_pool - %mana_cost);
  }

  return true;
}

function afxMagicSpellData::onImpact(%this, %spell, %caster, %impObj, %impPos, %impNorm)
{
  //echo("Default afxMagicSpellData::onImpact()");

  %rpg_data = %spell.extra;
  if (%rpg_data.directDamage != 0 || %rpg_data.areaDamageRadius > 0)
  {
    %dd_amt = %rpg_data.directDamage;
    %ad_amt = %rpg_data.areaDamage;
    %ad_rad = %rpg_data.areaDamageRadius;
    %ad_imp = %rpg_data.areaDamageImpulse;

    %this.onDamage(%spell, "directDamage", "spell", %impObj, %dd_amt, 0,
                   %impPos, %ad_amt, %ad_rad, %ad_imp);               
  }
}

function afxMagicSpellData::onInterrupt(%this, %spell, %caster)
{
  //echo("Default afxMagicSpellData::onInterrupt()");
  if (isObject(%caster))
  {
    if (%caster.spellBeingCast == %spell)
      %caster.spellBeingCast = "";
    %caster.setRechargeRate(%caster.getDataBlock().rechargeRate);

    //UAISK+AFX Interop Changes: Start
    if ($UAISK_Is_Available && !isObject(%caster.client))
      %caster.isCasting = false;
    //UAISK+AFX Interop Changes: End
  }
}

function afxMagicSpellData::onDeactivate(%this, %spell)
{
  //echo("Default afxMagicSpellData::onDeactivate()");
}

function afxMagicSpellData::readyToCast(%this, %caster, %target)
{
  //echo("Default afxMagicSpellData::readyToCast()");
  return true;
}

function afxMagicSpellData::onDamage(%this, %spell, %label, %flavor, %damaged_obj, 
                                     %amount, %count, %pos, %ad_amount, %radius, %impulse)
{
  // deal the direct damage
  if (isObject(%damaged_obj) && (%damaged_obj.getType() & $TypeMasks::PlayerObjectType))
    %damaged_obj.damage(%spell, %pos, %amount, %flavor);

  // deal area damage
  if (%radius > 0)
  {
    radiusDamage(%spell, %pos, %radius, %ad_amount, %flavor, %impulse);
  }
}

function afxTestSpellcastingDamageInterruption(%caster, %damage, %damageType)
{
  if (!isObject(%caster.spellBeingCast))
    return;

  %spell = %caster.spellBeingCast;
  %rpg_data = %spell.extra;
  if (%rpg_data.allowDamageInterrupts && %rpg_data.minDamageToInterrupt <= %damage)
  {
    %spell.interrupt();
    if (isObject(%caster.client))
      DisplayScreenMessage(%caster.client, "Spellcasting interrupted by damage.");
    //UAISK+AFX Interop Changes: Start
    else if ($UAISK_Is_Available)
      %caster.isCasting = false;
    //UAISK+AFX Interop Changes: End
  }
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
//  performSpellCastingInterrupt()
//
//    Used to interrupt a spell being cast by the player
//    associated with the given client.
//
function performSpellCastingInterrupt(%client)
{
  %caster = %client.player;
  if (isObject(%client.player.spellBeingCast))
  {
    %client.player.spellBeingCast.interrupt();
    %client.player.spellBeingCast = "";
    DisplayScreenMessage(%client, "Spellcasting interrupted.");
  }
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
