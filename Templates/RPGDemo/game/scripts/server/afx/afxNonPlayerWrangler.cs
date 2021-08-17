
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

function start_NonPlayerWrangler(%path_group)
{
  if (%path_group $= "")
    %path_group = "MissionGroup/NPCPaths";

  if (!isObject(%path_group))
  {
    warn("start_NonPlayerWrangler() -- failed to find path group, " @ %path_group @ ".");
    return;
  }

  %wrangler = new ScriptObject(NonPlayerWrangler);
  MissionCleanup.add(%wrangler);

  for (%i = 0; %i < %path_group.getCount(); %i++)
    %wrangler.spawnOnPath(%path_group.getObject(%i));
}

function stop_NonPlayerWrangler()
{
  if (isObject(NonPlayerWrangler))
    NonPlayerWrangler.delete();
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

function NonPlayerWrangler::spawnOnPath(%this, %path, %waypoint)
{
  // deal with special waypoints
  if (%waypoint $= "")
  {
    if (%path.firstWaypoint $= "random")
      %waypoint = getRandom(%path.getCount()-1);
    else
      %waypoint = %path.firstWaypoint;
  }

  // get a transform from the path
  %xfm = %path.getObject(%waypoint).getTransform();

  switch$ (%path.npcFlavor)
  {
    case "patrol":
      %npc = AIPlayer::spawnAt(%path.npcName, %xfm);
      %npc.followPath(%path, -1);
   case "guard":
      %npc = AIPlayer::spawnAt(%path.npcName, %xfm);
      %npc.path = %path;
  }

  // equip the NPC with a weapon
  if (%path.npcWeapon $= "crossbow")
  {
    %npc.mountImage(CrossbowImage,0);
    %npc.setInventory(CrossbowAmmo,1000);
  }

  %health = (%path.npcHealth $= "") ? 1.0 : mClamp(%path.npcHealth/100, 0, 100);
  if (%health < 0.01)
  {
    %npc.setDamageLevel(%npc.getDatablock().maxDamage);
    %npc.setRepairRate(0);
    %npc.setEnergyLevel(0);
    %npc.setRechargeRate(0);
    %npc.setShapeName("Dead Orc");
    %npc.startFade(1000, 4000, false);
  }
  else
  {
    %npc.setDamageLevel(%npc.getDatablock().maxDamage*(1.0 - %health));
    %npc.startFade(1000, 0, false);
  }

  if (%path.npcSpeedBias !$= "")
    %npc.setMovementSpeedBias(%path.npcSpeedBias);

  if (%path.npcMoveStuckTolerance !$= "")
    %npc.moveStuckTolerance = %path.npcMoveStuckTolerance;

  %npc.isNonPlayer = true;
  
  return %npc;
}

function NonPlayerWrangler::burnCorpse(%this, %corpse)
{
  if (!isObject(%corpse))
  {
    error("NonPlayerWrangler::burnCorpse() -- missing corpse object.");
    return;
  }

  if (%corpse.isEnabled())
  {
    error("NonPlayerWrangler::burnCorpse() -- corpse object is still alive!");
    return;
  }

  // get rid of the body
  %corpse.schedule(0, "startFade", 1000, 0, true);
  %corpse.schedule(1000+1000, "delete");

  // spawn at a random waypoint
  %this.schedule(getRandom(5000, 6000), "spawnOnPath", %corpse.path);
}

function NonPlayerWrangler::resurrectCorpse(%this, %corpse)
{
  if (!isObject(%corpse))
  {
    error("NonPlayerWrangler::resurrectCorpse() -- missing corpse object.");
    return;
  }

  if (%corpse.isEnabled())
  {
    error("NonPlayerWrangler::resurrectCorpse() -- corpse object is still alive!");
    return;
  }

  %corpse.setShapeName(%corpse.path.npcName);
  %corpse.setDamageLevel(%corpse.getDatablock().maxDamage*0.5);

  %corpse.setRechargeRate(%corpse.getDatablock().rechargeRate);
  %corpse.setRepairRate(%corpse.getDatablock().repairRate);


  schedule(1000, 0, afxBroadcastTargetStatusbarReset);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
