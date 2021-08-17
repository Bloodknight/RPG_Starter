//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

// Support function which applies damage to objects within the radius of
// some effect, usually an explosion.  This function will also optionally
// apply an impulse to each object.

$radiusDamage_coverageMask = $TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType | 
                             $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType;
                 
if (afxGetEngine() $= "TGEA")
        $radiusDamage_coverageMask |= $TypeMasks::AtlasObjectType;
        
if (afxGetEngine() !$= "TGE")
        $radiusDamage_coverageMask |= $TypeMasks::InteriorLikeObjectType;        
        
function radiusDamage(%sourceObject, %position, %radius, %damage, %damageType, %impulse, %excluded)
{
   // Use the container system to iterate through all the objects
   // within our explosion radius.  We'll apply damage to all ShapeBase
   // objects.
   InitContainerRadiusSearch(%position, %radius, $TypeMasks::ShapeBaseObjectType);

   %halfRadius = %radius / 2;
   while ((%targetObject = containerSearchNext()) != 0)
   {
      if (%targetObject == %excluded)
        continue;

      //UAISK+AFX Interop Changes: Start
      if ($UAISK_Is_Available && $AISK_FRIENDLY_FIRE == false && $AISK_FREE_FOR_ALL == false &&
        %sourceObject.caster.team == %targetObject.team)
            continue;
      //UAISK+AFX Interop Changes: End

      // Calculate how much exposure the current object has to
      // the explosive force.  The object types listed are objects
      // that will block an explosion.  If the object is totally blocked,
      // then no damage is applied.
      %coverage = calcExplosionCoverage(%position, %targetObject, $radiusDamage_coverageMask);
      if (%coverage == 0)
         continue;

      // Radius distance subtracts out the length of smallest bounding
      // box axis to return an appriximate distance to the edge of the
      // object's bounds, as opposed to the distance to it's center.
      %dist = containerSearchCurrRadiusDist();

      // Calculate a distance scale for the damage and the impulse.
      // Full damage is applied to anything less than half the radius away,
      // linear scale from there.
      %distScale = (%dist < %halfRadius)? 1.0 : 1.0 - ((%dist - %halfRadius) / %halfRadius);

      // Apply the damage
      %targetObject.damage(%sourceObject, %position, %damage * %coverage * %distScale, %damageType);

      if (isObject(%sourceObject) && %sourceObject.isMethod(onInflictedAreaDamage))
         %sourceObject.onInflictedAreaDamage(%targetObject, %damage, %damageType, %position);

      // Apply the impulse
      if (%impulse)
      {
         %impulseVec = VectorSub(%targetObject.getWorldBoxCenter(), %position);
         %impulseVec = VectorNormalize(%impulseVec);
         %impulseVec = VectorScale(%impulseVec, %impulse * %distScale);
         %targetObject.applyImpulse(%position, %impulseVec);
      }
   }
}
