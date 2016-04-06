namespace hw4
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Summary description for Property
    /// </summary>
    /// 
    
    public class Property
    {
        private double listPrice;
        private double sqFeet;
        private int beds;
        private int baths;
        private int year;

        public Property(double listPrice, double sqFeet, int beds, int baths, int year)
        {
            this.listPrice = listPrice;
            this.sqFeet = sqFeet;
            this.beds = beds;
            this.baths = baths;
            this.year = year;
        }

        public double ListPrice
        {
            get { return listPrice; }
        }
        public double SqFeet
        {
            get { return sqFeet; }
        }
        public int Beds
        {
            get { return beds; }
        }
        public int Baths
        {
            get { return baths; }
        }
        public int Year
        {
            get { return year; }
        }
    }
}