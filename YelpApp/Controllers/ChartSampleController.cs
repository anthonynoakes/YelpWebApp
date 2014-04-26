using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using HighlightsChartSample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HighlightsChartSample.Controllers 
{

    public class HomeController : Controller 
    {

        public SqlConnection db { get; set; }

        private string connectionString =
            "Data Source=(localdb)\\Projects;"
            + "Initial Catalog=YelpDb;"
            + "Integrated Security=True;"
            + "Connect Timeout=30;"
            + "Encrypt=False;"
            + "MultipleActiveResultSets=true;"
            + "TrustServerCertificate=False";

        public HomeController()
        {
            //Init db connection
            try
            {
                db = new SqlConnection(connectionString);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public ActionResult Index() 
        {
            //create a collection of data
            List<Point> yData = new List<Point>();
            List<Business> transaction = operateQuery1(0, 5, 100, 0, "yoga");            
            //modify data type to make it of array type
            //var yDataCounts = transaction.Select(i => new object[] { 
            //    Math.Round((i.miles_away / .015), 2)
            //}).ToArray();

            foreach (var x in transaction)
            {
                Point tmp = new Point();
                tmp.Y = Math.Round((x.miles_away / .015), 2);
                tmp.Events = new PointEvents { Click = "LineClickEvent" };
                yData.Add(tmp);
            }

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Yoga Businesses" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "within 25 Mile" })
                //load the X values
                //.SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Miles Away" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return toolTip(this); }",
                            UseHTML = true
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = true,
                                Cursor = Cursors.Pointer
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                        {
                            new Series {
                                Name = "Bussiness", 
                                Data = new Data(
                                        yData.ToArray()
                                        ) 
                            },       
                        })
                        .AddJavascripFunction("LineClickEvent", "toolTipClick(this.category)");

            return View(chart);
        }

        public ActionResult Query2i()
        {
            //create a collection of data
            List<Point> yData = new List<Point>();
            List<Business> transaction = operateQuery1(0, 5, 100, 0, "yoga");
            //modify data type to make it of array type
            //var yDataCounts = transaction.Select(i => new object[] { 
            //    Math.Round((i.miles_away / .015), 2)
            //}).ToArray();

            foreach (var x in transaction)
            {
                Point tmp = new Point();
                tmp.Y = Math.Round((x.miles_away / .015), 2);
                tmp.Events = new PointEvents { Click = "LineClickEvent" };
                yData.Add(tmp);
            }

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Food Business" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "within 1 Mile" })
                //load the X values
                //.SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Miles Away" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return toolTip(this); }",
                            UseHTML = true
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = true,
                                Cursor = Cursors.Pointer
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                        {
                            new Series {
                                Name = "Bussiness", 
                                Data = new Data(
                                        yData.ToArray()
                                        ) 
                            },       
                        })
                        .AddJavascripFunction("LineClickEvent", "toolTipClick(this.category)");

            return View(chart);
        }

        public ActionResult Query3()
        {
            //create a collection of data
            List<Point> yData = new List<Point>();
            List<Business> transaction = operateQuery1(0, 5, 100, 0, "yoga");
            //modify data type to make it of array type
            //var yDataCounts = transaction.Select(i => new object[] { 
            //    Math.Round((i.miles_away / .015), 2)
            //}).ToArray();

            foreach (var x in transaction)
            {
                Point tmp = new Point();
                tmp.Y = Math.Round((x.miles_away / .015), 2);
                tmp.Events = new PointEvents { Click = "LineClickEvent" };
                yData.Add(tmp);
            }

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Food Business" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "within 1 Mile" })
                //load the X values
                //.SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Miles Away" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return toolTip(this); }",
                            UseHTML = true
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = true,
                                Cursor = Cursors.Pointer
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                        {
                            new Series {
                                Name = "Bussiness", 
                                Data = new Data(
                                        yData.ToArray()
                                        ) 
                            },       
                        })
                        .AddJavascripFunction("LineClickEvent", "toolTipClick(this.category)");

            return View(chart);
        }       

        
        public string apiGetReviews(string business_id)
        {
            string result = "";


            return result;
        }

        public string reviewBuilder(string business_id, int offset)
        {
            return
                "select * from reviews "
                + "where business_id = '" + business_id + "' "
                + "order by date desc "
                + "offset " + offset + " rows "
                + "fetch next 30 rows only;";
        }

        public string apiCheckOpen(string business_id)
        {
            string result = "false";
            List<Hours> hoursResult = new List<Hours>();

            //If there are any results it is open
            string open = "select h.business_id from hours h "
                + "where h.business_id = '" + business_id + "' "
                + "and h.day_number = DATEPART(dw, GETDATE()) "
                + "and DATEPART(hh,h.[open]) <= DATEPART(hh, GETDATE()) "
                + "and DATEPART(hh,h.[close]) > DATEPART(hh, GETDATE())";

            string hours = "select h.day_number, DATEPART(hh, h.[open]) as [open], "
                + "DATEPART(hh, h.[close]) as [close] from  hours h "
                + "where h.business_id = '" + business_id + "' "
                + "order by day_number asc;";


            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            command.CommandText = open;
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult q_result;

            try
            {
                db.Open();
                q_result = command.BeginExecuteReader();
                while (!q_result.IsCompleted)
                    System.Threading.Thread.Sleep(10);

                using (SqlDataReader reader = command.EndExecuteReader(q_result))
                    while (reader.Read())
                        result = "true";

                db.Close();
            }
            catch (Exception e)
            {
                result = "false";
            }

            command = db.CreateCommand();
            command.CommandText = hours;
            command.CommandType = System.Data.CommandType.Text;
            
            try
            {
                db.Open();
                q_result = command.BeginExecuteReader();
                while (!q_result.IsCompleted)
                    System.Threading.Thread.Sleep(10);

                using (SqlDataReader reader = command.EndExecuteReader(q_result))
                    while (reader.Read())
                    {
                        Hours tmp = new Hours();
                        int _day = -1, _open = -1, _close = -1;

                        Int32.TryParse(reader.GetValue(0).ToString(), out _day);
                        Int32.TryParse(reader.GetValue(1).ToString(), out _open);
                        Int32.TryParse(reader.GetValue(2).ToString(), out _close);

                        tmp.day_number = _day;
                        tmp.open = _open;
                        tmp.close = _close;

                        hoursResult.Add(tmp);
                    }
                
                db.Close();
            }
            catch (Exception e)
            {
                result = "false";
            }

            var returnVar = new
            {
                open = result,
                hours = hoursResult
            };

            string json = new JavaScriptSerializer().Serialize(returnVar);

            return json;
        }

        //public string apiGetQuery1(double min, double max, double miles, int offset, string category)
        //{
        //    //create a collection of data
        //    List<Business> transaction = operateQuery1(min, max, miles, offset, category);

        //    var obj = transaction.Select(i => new object[] { 
        //        i.business_id,
        //        i.name,
        //        i.stars,
        //        i.normalized_stars,
        //        Math.Round((i.miles_away / .015), 2)
        //    }).ToArray();

        //    //Serialize to JSON string
        //    return new JavaScriptSerializer().Serialize(obj);
        //}

        #region Query 1

        public string apiGetQuery1_1(double min, double max, double miles, int offset, string category)
        {
            List<Business> transaction = operateQuery1(min, max, miles, offset, category);

            var obj = transaction.Select(i => new object[] { 
                i.business_id,
                i.name,
                i.stars,
                i.normalized_stars,
                Math.Round((i.miles_away / .015), 2)
            }).ToArray();

            List<double> data = new List<double>();
            foreach (var x in transaction)
                data.Add(Math.Round((x.miles_away / .015), 2));

            var result = new
            {
                series = data,
                data = obj
            };

            return new JavaScriptSerializer().Serialize(result);
        }
        
        private List<Business> operateQuery1(double min, double max, double miles, int offset, string category)
        {
            List<Business> results = new List<Business>();

            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            int count = 0;
            command.CommandText = query_1_builder(min, max, miles, offset, category);
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult result;

            try
            {
                db.Open();
                result = command.BeginExecuteReader();
                while (!result.IsCompleted)
                {
                    count += 1;
                    //Console.WriteLine("Waiting ({0})", count);
                    // Wait for 1/10 second, so the counter 
                    // does not consume all available resources  
                    // on the main thread.
                    System.Threading.Thread.Sleep(10);
                }

                int i = 0;
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    while (reader.Read())
                    {
                        //[0] = name, [1] = stars, [2] = business_id
                        double _stars = -1,
                               _normalize_stars = -1,
                               _miles_away = -1;

                        //Gather all data from query
                        string _name = reader.GetValue(0).ToString();
                        Double.TryParse(reader.GetValue(1).ToString(), out _stars);
                        Double.TryParse(reader.GetValue(2).ToString(), out _normalize_stars);
                        string _bid = reader.GetValue(3).ToString();
                        Double.TryParse(reader.GetValue(4).ToString(), out _miles_away);

                        results.Add(
                            new Business()
                            {
                                business_id = _bid,
                                name = _name,
                                stars = _stars,
                                normalized_stars = _normalize_stars,
                                miles_away = _miles_away
                            });
                    }
                }
                db.Close();
            }
            catch (Exception e)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            db.Close();

            return results;
        }

        public string query_1_builder(double min = 1.0, double max = 5.0, double miles = 100, int offset = 0, string category = "")
        {
            string query =
                "select x.name, x.stars, x.normalized_stars, x.business_id, x.miles_away from "
                + "(select	b.name, b.stars, b.normalized_stars, b.business_id, "
                + "SQRT( "
                + "SQUARE(b.longitude - (-111.788)) + "
                + "SQUARE(b.latitude - (33.423))) as miles_away "
                + "from business b "
                + "where b.stars >= " + min 
                + "and b.stars <= " + max
                + ") x "
                + "inner join categories c "
                + "on x.business_id = c.business_id "
                + "where x.miles_away < (.015 * " + miles + ") "
                + "and c.name like '%" + category + "%' "
                + "order by x.miles_away "
                + "offset " + offset + " rows "
                + "fetch next 30 rows only;";

            return query;
        }

        #endregion

        #region Query 2i

        public string apiGetQuery2i(double min, double max, int offset, string category)
        {
            List<Business> transaction = operateQuery2i(min, max, offset, category);

            var obj = transaction.Select(i => new object[] { 
                i.business_id,
                i.name,
                i.stars,
                i.normalized_stars,
                Math.Round((i.miles_away / .015), 2)
            }).ToArray();

            List<double> data = new List<double>();
            foreach (var x in transaction)
                data.Add(Math.Round((x.miles_away / .015), 2));

            var result = new
            {
                series = data,
                data = obj
            };

            return new JavaScriptSerializer().Serialize(result);
        }

        private List<Business> operateQuery2i(double min, double max, int offset, string category)
        {
            List<Business> results = new List<Business>();

            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            int count = 0;
            command.CommandText = query_2i_builder(min, max, offset, category);
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult result;

            try
            {
                db.Open();
                result = command.BeginExecuteReader();
                while (!result.IsCompleted)
                {
                    count += 1;
                    //Console.WriteLine("Waiting ({0})", count);
                    // Wait for 1/10 second, so the counter 
                    // does not consume all available resources  
                    // on the main thread.
                    System.Threading.Thread.Sleep(10);
                }

                int i = 0;
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    while (reader.Read())
                    {
                        //[0] = name, [1] = stars, [2] = business_id
                        double _stars = -1,
                               _normalize_stars = -1,
                               _miles_away = -1;

                        //Gather all data from query
                        string _name = reader.GetValue(0).ToString();
                        Double.TryParse(reader.GetValue(1).ToString(), out _stars);
                        Double.TryParse(reader.GetValue(2).ToString(), out _normalize_stars);
                        string _bid = reader.GetValue(3).ToString();
                        Double.TryParse(reader.GetValue(4).ToString(), out _miles_away);

                        results.Add(
                            new Business()
                            {
                                business_id = _bid,
                                name = _name,
                                stars = _stars,
                                normalized_stars = _normalize_stars,
                                miles_away = _miles_away
                            });
                    }
                }
                db.Close();
            }
            catch (Exception e)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            db.Close();

            return results;
        }

        public string query_2i_builder(double min = 1.0, double max = 5.0, int offset = 0, string category = "")
        {
            string query =
                "select max(b.name), [June 2011].name,  from ( "
                + "select c.name, c.business_id, r.stars from reviews r "
                + "inner join categories c "
                + "on r.business_id = c.business_id "
                + "where month(r.date) = 6 "
                + "and year(r.date) = 2011 "
                + ") [June 2011] "
                + "inner join business b "
                + "on b.business_id = [June 2011].business_id "
                + "where [June 2011].name like '%" + category + "%' "
                + "group by [June 2011].name;";

            return query;
        }

        #endregion

        #region Query 2ii

        public ActionResult Query2ii()
        {
            //create a collection of data
            List<Point> yData1 = new List<Point>();
            List<Point> yData2 = new List<Point>();
            List<Query2ii> transaction = operateQuery2ii(0, 0, 0, 12, 2011, 2011, 0);
            //modify data type to make it of array type
            //var yDataCounts = transaction.Select(i => new object[] { 
            //    Math.Round((i.miles_away / .015), 2)
            //}).ToArray();

            foreach (var x in transaction)
            {
                Point tmp1 = new Point();
                tmp1.Y = x.january_average;
                tmp1.Events = new PointEvents { Click = "LineClickEvent" };
                yData1.Add(tmp1);

                Point tmp2 = new Point();
                tmp2.Y = x.december_average;
                tmp2.Events = new PointEvents { Click = "LineClickEvent" };
                yData2.Add(tmp2);
            }

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Food Business" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "within 1 Mile" })
                //load the X values
                //.SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Miles Away" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return toolTip(this); }",
                            UseHTML = true
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = true,
                                Cursor = Cursors.Pointer
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                        {
                            new Series {
                                Name = "Then", 
                                Data = new Data(
                                        yData1.ToArray()
                                        ) 
                            },
                            new Series {
                                Name = "Now", 
                                Data = new Data(
                                        yData2.ToArray()
                                        ) 
                            }
                        })
                        .AddJavascripFunction("LineClickEvent", "toolTipClick(this.category)");

            return View(chart);
        }

        public string apiGetQuery2ii(double diff, double stars, int start_month, int stop_month, int start_year, int stop_year, int offset)
        {
            List<Query2ii> transaction = operateQuery2ii(diff, stars, start_month, stop_month, start_year, stop_year, offset);

            var obj = transaction.Select(i => new object[] { 
                i.business_id,
                i.name,
                i.stars,
                i.january_average,
                i.december_average
            }).ToArray();

            List<double> data1 = new List<double>();
            List<double> data2 = new List<double>();
            foreach (var x in transaction)
                data1.Add(x.january_average);
            foreach (var x in transaction)
                data2.Add(x.december_average);

            var result = new
            {
                series1 = data1,
                series2 = data2,
                data = obj
            };

            return new JavaScriptSerializer().Serialize(result);
        }

        private List<Query2ii> operateQuery2ii(double diff, double stars, int start_month, int stop_month, int start_year, int stop_year, int offset)
        {
            List<Query2ii> results = new List<Query2ii>();

            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            int count = 0;
            command.CommandText = query_2ii_builder(diff, stars, start_month, stop_month, start_year, stop_year, offset);
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult result;

            try
            {
                db.Open();
                result = command.BeginExecuteReader();
                while (!result.IsCompleted)
                {
                    count += 1;
                    System.Threading.Thread.Sleep(10);
                }

                int i = 0;
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    while (reader.Read())
                    {
                        double _stars = -1,
                            jan = -1,
                            dec = -1;
                        
                        string _bid = reader.GetValue(0).ToString();
                        string _name = reader.GetValue(1).ToString();

                        Double.TryParse(reader.GetValue(2).ToString(), out _stars);
                        Double.TryParse(reader.GetValue(3).ToString(), out jan);
                        Double.TryParse(reader.GetValue(4).ToString(), out dec);

                        results.Add(
                            new Query2ii()
                            {
                                business_id = _bid,
                                name = _name,
                                stars = _stars,
                                january_average = jan,
                                december_average = dec
                            });
                    }
                }
                db.Close();
            }
            catch (Exception e)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            db.Close();

            return results;
        }

        public string query_2ii_builder(double diff, double stars, int start_month, int stop_month, int start_year, int stop_year, int offset)
        {
            return
                "select b.business_id, b.name, b.stars, january.avgerage, december.avgerage from ( "
                        + "select avg(stars) as avgerage, reviews.business_id from reviews  "
                            + "where month(reviews.date) = " + start_month + " "
                            + "and year(reviews.date) = " + start_year + " "
                            + "group by business_id "
                        + ") january "
                    + "inner join ( "
                        + "select avg(stars) as avgerage, reviews.business_id from reviews  "
                            + "where month(reviews.date) = " + stop_month + " "
                            + "and year(reviews.date) = " + stop_year + " "
                            + "group by business_id "
                        + ") december "
                    + "on january.business_id = december.business_id "
                    + "inner join business b "
                    + "on january.business_id = b.business_id "
                        + "where january.avgerage < ( december.avgerage - " + diff + ") "
                        + "and b.stars >= " + stars + " "
                        + "order by b.stars desc "
                        + "offset " + offset + " rows "
                        + "fetch next 30 rows only;";
        }

        #endregion

        /*#region Query 3

        public string apiGetQuery2(double min, double max, double miles, string category)
        {
            List<Business> transaction = operateQuery2(min, max, miles, offset, category);

            var obj = transaction.Select(i => new object[] { 
                i.business_id,
                i.name,
                i.stars,
                i.normalized_stars,
                Math.Round((i.miles_away / .015), 2)
            }).ToArray();

            List<double> data = new List<double>();
            foreach (var x in transaction)
                data.Add(Math.Round((x.miles_away / .015), 2));

            var result = new
            {
                series = data,
                data = obj
            };

            return new JavaScriptSerializer().Serialize(result);
        }

        private List<Business> operateQuery2(double min, double max, double miles, int offset, string category)
        {
            List<Business> results = new List<Business>();

            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            int count = 0;
            command.CommandText = query_2_builder(min, max, miles, offset, category);
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult result;

            try
            {
                db.Open();
                result = command.BeginExecuteReader();
                while (!result.IsCompleted)
                {
                    count += 1;
                    //Console.WriteLine("Waiting ({0})", count);
                    // Wait for 1/10 second, so the counter 
                    // does not consume all available resources  
                    // on the main thread.
                    System.Threading.Thread.Sleep(10);
                }

                int i = 0;
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    while (reader.Read())
                    {
                        //[0] = name, [1] = stars, [2] = business_id
                        double _stars = -1,
                               _normalize_stars = -1,
                               _miles_away = -1;

                        //Gather all data from query
                        string _name = reader.GetValue(0).ToString();
                        Double.TryParse(reader.GetValue(1).ToString(), out _stars);
                        Double.TryParse(reader.GetValue(2).ToString(), out _normalize_stars);
                        string _bid = reader.GetValue(3).ToString();
                        Double.TryParse(reader.GetValue(4).ToString(), out _miles_away);

                        results.Add(
                            new Business()
                            {
                                business_id = _bid,
                                name = _name,
                                stars = _stars,
                                normalized_stars = _normalize_stars,
                                miles_away = _miles_away
                            });
                    }
                }
                db.Close();
            }
            catch (Exception e)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            db.Close();

            return results;
        }

        public string query_2_builder(double min = 1.0, double max = 5.0, double miles = 100, int offset = 0, string category = "")
        {
            string query =
                "select x.name, x.stars, x.normalized_stars, x.business_id, x.miles_away from "
                + "(select	b.name, b.stars, b.normalized_stars, b.business_id, "
                + "SQRT( "
                + "SQUARE(b.longitude - (-111.788)) + "
                + "SQUARE(b.latitude - (33.423))) as miles_away "
                + "from business b "
                + "where b.stars >= " + min
                + "and b.stars <= " + max
                + ") x "
                + "inner join categories c "
                + "on x.business_id = c.business_id "
                + "where x.miles_away < (.015 * " + miles + ") "
                + "and c.name like '%" + category + "%' "
                + "order by x.miles_away "
                + "offset " + offset + " rows "
                + "fetch next 30 rows only;";

            return query;
        }

        #endregion*/

        #region Query 4

        public ActionResult Query4()
        {
            //create a collection of data
            List<Point> yData1 = new List<Point>();
            List<Point> yData2 = new List<Point>();
            List<Query4> transaction = operateQuery4(10, 0, 0);
            //modify data type to make it of array type
            //var yDataCounts = transaction.Select(i => new object[] { 
            //    Math.Round((i.miles_away / .015), 2)
            //}).ToArray();

            foreach (var x in transaction)
            {
                Point tmp1 = new Point();
                tmp1.Y = x.stars;
                tmp1.Events = new PointEvents { Click = "LineClickEvent" };
                yData1.Add(tmp1);

                Point tmp2 = new Point();
                tmp2.Y = x.revised_stars;
                tmp2.Events = new PointEvents { Click = "LineClickEvent" };
                yData2.Add(tmp2);
            }

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Emitting Low Quality Reviews" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "mmax 10 erros per review" })
                //load the X values
                //.SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Stars" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return toolTip(this); }",
                            UseHTML = true
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = true,
                                Cursor = Cursors.Pointer
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                        {
                            new Series {
                                Name = "Stars", 
                                Data = new Data(
                                        yData1.ToArray()
                                        ) 
                            },
                            new Series {
                                Name = "Revised", 
                                Data = new Data(
                                        yData2.ToArray()
                                        ) 
                            }
                        })
                        .AddJavascripFunction("LineClickEvent", "toolTipClick(this.category)");

            return View(chart);
        }

        public string apiGetQuery4(int max_errors, double diff, int offset)
        {
            List<Query4> transaction = operateQuery4(max_errors, diff, offset);

            var obj = transaction.Select(i => new object[] { 
                i.business_id,
                i.name,
                i.stars,
                i.revised_stars
            }).ToArray();

            List<double> data1 = new List<double>();
            List<double> data2 = new List<double>();
            foreach (var x in transaction)
                data1.Add(x.stars);
            foreach (var x in transaction)
                data2.Add(x.revised_stars);

            var result = new
            {
                series1 = data1,
                series2 = data2,
                data = obj
            };

            return new JavaScriptSerializer().Serialize(result);
        }

        private List<Query4> operateQuery4(int max_errors, double diff, int offset)
        {
            List<Query4> results = new List<Query4>();

            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            int count = 0;
            command.CommandText = query_4_builder(max_errors, diff, offset);
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult result;

            try
            {
                db.Open();
                result = command.BeginExecuteReader();
                while (!result.IsCompleted)
                {
                    count += 1;
                    //Console.WriteLine("Waiting ({0})", count);
                    // Wait for 1/10 second, so the counter 
                    // does not consume all available resources  
                    // on the main thread.
                    System.Threading.Thread.Sleep(10);
                }

                int i = 0;
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    while (reader.Read())
                    {
                        //[0] = name, [1] = stars, [2] = business_id
                        double _stars = -1,
                               _normalize_stars = -1;

                        //Gather all data from query
                        string _bid = reader.GetValue(0).ToString();
                        string _name = reader.GetValue(1).ToString();
                        Double.TryParse(reader.GetValue(2).ToString(), out _stars);
                        Double.TryParse(reader.GetValue(3).ToString(), out _normalize_stars);

                        results.Add(
                            new Query4()
                            {
                                business_id = _bid,
                                name = _name,
                                stars = _stars,
                                revised_stars = _normalize_stars
                            });
                    }
                }
                db.Close();
            }
            catch (Exception e)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            db.Close();

            return results;
        }

        public string query_4_builder(int max_errors, double diff, int offset)
        {
            return
                "select b.business_id, b.name, b.stars, r.stars from ( "
                    + "select avg(r.stars) as stars, r.business_id from reviews r "
                        + "where r.errors < " + max_errors + " "
                        + "group by r.business_id "
                    + ") r "
                    + "inner join business b "
                    + "on r.business_id = b.business_id "
                        + "where abs(b.stars - r.stars) >= " + diff + " "
                        + "order by abs(b.stars - r.stars) desc "
                        + "offset " + offset +" rows "
                        + "fetch next 30 rows only;";
        }

        #endregion

        #region Query 5

        public ActionResult Query5()
        {
            //create a collection of data
            List<Point> yData = new List<Point>()
            {
                new Point()
                {
                    Y = 0,
                    Events = new PointEvents { Click = "LineClickEvent"}
                }
            };

            //instanciate an object of the Highcharts type
            var chart = new Highcharts("chart")
                //define the type of chart 
                        .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line })
                //overall Title of the chart 
                        .SetTitle(new Title { Text = "Best Users" })
                //small label below the main Title
                        .SetSubtitle(new Subtitle { Text = "based on cool, funny, and useful" })
                //load the X values
                //.SetXAxis(new XAxis { Categories = xDataMonths })
                //set the Y title
                        .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Miles Away" } })
                        .SetTooltip(new Tooltip
                        {
                            Enabled = true,
                            Formatter = @"function() { return toolTip(this); }",
                            UseHTML = true
                        })
                        .SetPlotOptions(new PlotOptions
                        {
                            Line = new PlotOptionsLine
                            {
                                DataLabels = new PlotOptionsLineDataLabels
                                {
                                    Enabled = true
                                },
                                EnableMouseTracking = true,
                                Cursor = Cursors.Pointer
                            }
                        })
                //load the Y values 
                        .SetSeries(new[]
                        {
                            new Series {
                                Name = "Loading . . . ", 
                                Data = new Data(
                                        yData.ToArray()
                                        ) 
                            },       
                        })
                        .AddJavascripFunction("LineClickEvent", "toolTipClick(this.category)");

            return View(chart);
        }

        public string apiGetQuery5(int offset)
        {
            List<Query5> transaction = operateQuery5(offset);

            var obj = transaction.Select(i => new object[] { 
                i.name,
                i.business_name,
                i.stars,
                i.date,
                i.text,
                i.total
            }).ToArray();

            List<double> data = new List<double>();
            foreach (var x in transaction)
                data.Add(x.total);

            var result = new
            {
                series = data,
                data = obj
            };

            return new JavaScriptSerializer().Serialize(result);
        }

        private List<Query5> operateQuery5(int offset)
        {
            List<Query5> results = new List<Query5>();

            // create a SqlCommand object for this connection
            SqlCommand command = db.CreateCommand();
            int count = 0;
            command.CommandText = query_5_builder(offset);
            command.CommandType = System.Data.CommandType.Text;
            IAsyncResult result;

            try
            {
                db.Open();
                result = command.BeginExecuteReader();
                while (!result.IsCompleted)
                {
                    count += 1;
                    //Console.WriteLine("Waiting ({0})", count);
                    // Wait for 1/10 second, so the counter 
                    // does not consume all available resources  
                    // on the main thread.
                    System.Threading.Thread.Sleep(10);
                }

                int i = 0;
                using (SqlDataReader reader = command.EndExecuteReader(result))
                {
                    while (reader.Read())
                    {

                        string _name;
                        string _bname;
                        double _stars;
                        string _text;
                        DateTime _date;
                        int _total;

                        //Gather all data from query
                        _name = reader.GetValue(0).ToString();
                        _bname = reader.GetValue(1).ToString();
                        Double.TryParse(reader.GetValue(2).ToString(), out _stars);
                        _text = reader.GetValue(3).ToString();
                        DateTime.TryParse(reader.GetValue(4).ToString(), out _date);
                        Int32.TryParse(reader.GetValue(5).ToString(), out _total); 
                        
                        results.Add(
                            new Query5()
                            {
                                name = _name,
                                business_name = _bname,
                                stars = _stars,
                                text = _text,
                                date = _date,
                                total = _total
                            });
                    }
                }
                db.Close();
            }
            catch (Exception e)
            {
                System.Media.SystemSounds.Beep.Play();
            }

            db.Close();

            return results;
        }

        public string query_5_builder(int offset)
        {
            return
                "select u.name, b.name, r.stars, r.text, r.[date], (u.cool + u.funny + u.useful)/u.review_count as 'Total' from users u "
                + "inner join reviews r "
                + "on u.user_id = r.user_id "
                + "inner join business b "
                + "on r.business_id = b.business_id "
                + "order by (u.cool + u.funny + u.useful)/u.review_count desc "
                + "offset " + offset + " rows "
                + "fetch next 30 rows only;";
        }

        #endregion

        


        

        

        public void query_3_builder()
        {
            string query =
                "select * from business "
                + "sorder by normalized_stars desc;";
        }
    }
}
