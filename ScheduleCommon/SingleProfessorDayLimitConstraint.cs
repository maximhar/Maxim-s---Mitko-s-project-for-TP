﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleCommon
{
    [Serializable]
    class SingleProfessorDayLimitConstraint : IConstraint
    {
        private Professor prof;
        private int classLimit;

        public SingleProfessorDayLimitConstraint(Professor aProfessor, int aClassLimit)
        {
            prof = aProfessor;
            classLimit = aClassLimit;
        }

        public ConstraintResult Check(Schedule sched)
        {
            bool pass = true;
            StringBuilder errorContainer = new StringBuilder();
            int classCounter;
            
            for (int day = 0; day < 6; day++) 
            {
                classCounter = 0;
                if (sched[day].Count == 0)
                {
                    continue;
                }

                foreach (var group in Configuration.Instance.Groups)
                {
                    foreach (var classs in sched[day][group])
                    {
                        if (prof == classs.Course.Professor)
                        {
                            classCounter++;
                        }
                    }
                }

                if (classCounter > classLimit)
                {
                    pass = false;
                    string error = string.Format("Professor class per day count exceeds limit of {0}: professor {1} has {2} classes on day {3}",
                        classLimit, prof, classCounter, day);
                    errorContainer.AppendLine(error);
                }

                /*
                foreach (var proff in Configuration.Instance.Professors)
                {
                    //var group = Configuration.Instance.Groups
                    var someprof = sched[day][Configuration.Instance.Groups[0]][0].Course.Professor;
                
                }
                */
            }
            return new ConstraintResult(pass, errorContainer.ToString());
        }
    }
}
