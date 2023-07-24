using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XafBlazorMapsGps.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Location : BaseObject
    { 
        public Location(Session session) : base(session)
        { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        private double _Latitude;
        public double Latitude
        {
            get { return _Latitude; }
            set { SetPropertyValue<double>(nameof(Latitude), ref _Latitude, value); }
        }


        private double _Longitude;
        public double Longitude
        {
            get { return _Longitude; }
            set { SetPropertyValue<double>(nameof(Longitude), ref _Longitude, value); }
        }


    }
}