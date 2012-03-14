﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleCommon
{
    public class Class
    {
        public StudentGroup Group { get; set; }
        public Course Course { get; set; }
        public TimeSpan Length { get; set; }
        public Room Room { get; set; }
        public Class(StudentGroup aGroup, Course aCourse, TimeSpan aLength, Room aRoom)
        {
            Group = aGroup;
            Course = aCourse;
            Length = aLength;
            Room = aRoom;
        }
        public override string ToString()
        {
            return string.Format("{0}, group {1}, length {2}, room {3}", Course, Group, Length, Room);
        }
    }
}