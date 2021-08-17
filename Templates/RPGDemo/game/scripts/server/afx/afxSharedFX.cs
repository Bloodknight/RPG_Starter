
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Shared Effects Elements
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

// Shared Spell Audio Descriptions

datablock SFXDescription(SpellAudioDefault_AD)
{
  volume             = 1.0;
  isLooping          = false;
  is3D               = true;
  ReferenceDistance  = 2.0;
  MaxDistance        = 100.0;
  channel            = $SimAudioType;
};

datablock SFXDescription(SpellAudioLoop_AD : SpellAudioDefault_AD)
{
  isLooping= true;
};

// good for casting sounds near spellecaster //

datablock SFXDescription(SpellAudioCasting_soft_AD : SpellAudioDefault_AD)
{
  ReferenceDistance= 2.0;
  MaxDistance = 30;
};

datablock SFXDescription(SpellAudioCasting_AD : SpellAudioDefault_AD)
{
  ReferenceDistance= 2.0;
  MaxDistance = 55;
};

datablock SFXDescription(SpellAudioCasting_loud_AD : SpellAudioDefault_AD)
{
  ReferenceDistance= 2.0;
  MaxDistance = 80;
};

// good for impacts //

datablock SFXDescription(SpellAudioImpact_AD : SpellAudioDefault_AD)
{
  ReferenceDistance= 2.0;
  MaxDistance= 120.0;
};

// good for projectiles //

datablock SFXDescription(SpellAudioMissileLoop_AD : SpellAudioDefault_AD)
{
  isLooping= true;
  ReferenceDistance= 2.0;
};

datablock SFXDescription(SpellAudioMissileLoop_loud_AD : SpellAudioDefault_AD)
{
  isLooping= true;
  ReferenceDistance= 2.0;
};

// good for shockwaves //

datablock SFXDescription(SpellAudioShockwaveLoop_AD : SpellAudioDefault_AD)
{
  isLooping= true;
  ReferenceDistance= 2.0;
  MaxDistance= 70.0;
};

datablock SFXDescription(SpellAudioShockwaveLoop_soft_AD : SpellAudioDefault_AD)
{
  isLooping= true;
  ReferenceDistance= 2.0;
  MaxDistance= 25.0;
};

datablock afxXM_SpinData(SHARED_MainZodeRevealLight_spin1_XM)
{
  spinAxis = "0 0 1";
  spinAngle = 0;
  spinRate = -30;
};

// Shared Freeze X-Mod. Usually used to stick zodiacs to the
// ground.
datablock afxXM_FreezeData(SHARED_freeze_XM)
{
  mask = $afxXfmMod::POS;
};

// Shared AltitudeConform X-Mod. Used to measure separate altitudes
// of zodiacs over terrain and interiors. 
datablock afxXM_AltitudeConformData(SHARED_AltitudeConform_XM)
{
  height = 0.0;
};

datablock afxXM_AltitudeConformData(SHARED_freeze_AltitudeConform_XM)
{
  height = 0.0;
  freeze = true;
};

datablock afxZodiacData(SHARED_SelectronZodiac_CE)
{  
  altitudeFalloff = 1.0;
  altitudeMax = 2.5;
  altitudeFades = true;
  verticalRange = "1.0 1.0";
  scaleVerticalRange = false;
  gradientRange = "0.0 45.0";
  useGradientRange = true;
};

datablock afxZodiacData(SHARED_ZodiacBase_CE)
{  
  altitudeFalloff = 1.0;
  altitudeMax = 2.5;
  altitudeFades = true;
  verticalRange = "1.0 1.0";
  scaleVerticalRange = false;
  gradientRange = "0.0 45.0";
  useGradientRange = true;
};

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
