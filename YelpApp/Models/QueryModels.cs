using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HighlightsChartSample.Models
{
    public class Query1
    {
        public string name { get; set; }
        public string bid { get; set; }
        public double miles_away { get; set; }
        public double Stars { get; set; }
        public int count { get; set; } 
        public string categories { get; set; }
        //public List<string> categories { get; set; }
    }

    public class Business
    {
        public string business_id { get; set; }
        public string name { get; set; }
        public double stars { get; set; }
        public double normalized_stars { get; set; }
        public double miles_away { get; set; }
    }

    public class Hours
    {
        public int day_number { get; set; }
        public int open { get; set; }
        public int close { get; set; }
    }

    public class Query2i
    {
        public double miles_away { get; set; }
        public int count { get; set; }
        public string categories { get; set; }
        //public List<string> categories { get; set; }
    }

    ////b.business_id, b.name, b.stars, january.avgerage, december.avgerage
    public class Query2ii
    {
        public string business_id { set; get; }
        public string name { set; get; }
        public double stars { set; get; }
        public double january_average { set; get; }
        public double december_average { set; get; }
    }

    public class Query3
    {
        public double miles_away { get; set; }
        public int count { get; set; }
        public string categories { get; set; }
        //public List<string> categories { get; set; }
    }

    public class Query4
    {
        //b.business_id, b.name, b.stars, r.stars
        public string business_id { set; get; }
        public string name { set; get; }
        public double stars { set; get; }
        public double revised_stars { set; get; }
    }

    public class Query5
    {
        public string name { get; set; }
        public string business_name { get; set; }
        public double stars { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }
        public int total { get; set; }
    }

    public class Reviews
    {
        public string review_id { set; get; }
        public string user_id { set; get; }
        public int stars { set; get; }
        public DateTime date { set; get; }
        public string text { set; get; }
        public int funny { set; get; }
        public int useful { set; get; }
        public int cool { set; get; }
        public string business_id { set; get; }
        public int errors { set; get; }
    }
}