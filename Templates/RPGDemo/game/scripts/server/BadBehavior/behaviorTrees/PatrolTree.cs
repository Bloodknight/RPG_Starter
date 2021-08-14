//--- OBJECT WRITE BEGIN ---
new Root(PatrolTree) {
   canSave = "1";
   canSaveDynamicFields = "1";

   new Sequence() {
      canSave = "1";
      canSaveDynamicFields = "1";

      new ScriptedBehavior() {
         preconditionMode = "ONCE";
         internalName = "Move_to_closest_node_on_path";
         class = "moveToClosestNodeTask";
         canSave = "1";
         canSaveDynamicFields = "1";
      };
      new WaitForSignal() {
         signalName = "onReachDestination";
         internalName = "onReachDestination";
         canSave = "1";
         canSaveDynamicFields = "1";
      };
      new Loop() {
         numLoops = "0";
         terminationPolicy = "ON_FAILURE";
         canSave = "1";
         canSaveDynamicFields = "1";

         new Sequence() {
            canSave = "1";
            canSaveDynamicFields = "1";

            new ScriptedBehavior() {
               preconditionMode = "ONCE";
               internalName = "move_along_path";
               class = "patrolTask";
               canSave = "1";
               canSaveDynamicFields = "1";
            };
            new WaitForSignal() {
               signalName = "onReachDestination";
               internalName = "onReachDestination";
               canSave = "1";
               canSaveDynamicFields = "1";
            };
         };
      };
   };
};
//--- OBJECT WRITE END ---
