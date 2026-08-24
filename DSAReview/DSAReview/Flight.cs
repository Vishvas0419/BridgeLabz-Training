using System;
using System.Collections.Generic;
using System.Text;

namespace DSAReview
{
    public class Flight
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public TimeOnly BoardingTime { get; set; }
        //public bool IsCancel {  get; set; }
        //public bool IsDelayed {  get; set; }
        public Flight(int code, string name, TimeOnly boardingTime /*,bool isCancel,bool isDelayed*/)
        {
            Code = code;
            Name = name;
            BoardingTime = boardingTime;
            //IsCancel = isCancel;
            //IsDelayed = isDelayed;
        }
    }
}
