﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleCommon
{
    public class RoomTimeOverlapConstraint : IConstraint
    {
        public RoomTimeOverlapConstraint()
        {
        }
        public ConstraintResult Check(Schedule sched)
        {
            StringBuilder errorContainer = new StringBuilder();
            for (int day = 0; day < 6; day++){ 
                for (int groupN=0; groupN < Configuration.Instance.Groups.Count-1; groupN++){
                    var group = Configuration.Instance.Groups[groupN];
                    for (int classsN = 0; classsN < sched[day][group].Count; classsN++){
                        int groupN2 = groupN;
                        while (groupN2 < Configuration.Instance.Groups.Count)
                        {
                            var group2 = Configuration.Instance.Groups[groupN2];
                            var classs = sched[day][group][classsN];
                            var classs2 = sched[day][group2][classsN];

                            if (classs.Room == classs2.Room)
                            {

                                var start1 = sched.GetStartTimeForClass(day, group, classs);
                                var start2 = sched.GetStartTimeForClass(day, group2, classs2);
                                if (start1 + classs.Length >= start2 && start2 <= start1 + classs.Length && start1+classs.Length<=start2 + classs2.Length)
                                {
                                    string error = string.Format("Room conflict: room {0} conflicts between group {1} and group {2} in day {3}",
                                        classs.Room, group, group2, day);
                                    errorContainer.AppendLine(error);
                                }
                            }
                        }


                    }
                }
            }



                return new ConstraintResult(false, "Constraint not implemented yet.");
        }
    }
}