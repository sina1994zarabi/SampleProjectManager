using System;
using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.DC;
using AggregatedAttribute = DevExpress.Xpo.AggregatedAttribute;

namespace SimpleProjectManager.Module.BusinessObjects.Marketing
{
    [NavigationItem("Marketing")]
    public class Customer : XPObject
    {
        
        public Customer(Session session) : base(session) { }

        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string Occupation { get; set; }

        [Association("Customer-Testimonials")]
        [Aggregated]
        public XPCollection<Testimonial> Testimonials
        {
            get { return GetCollection<Testimonial>("Testimonials"); }
        }

        
        public string FullName
        {
            get
            {
                string namePart = string.Format("{0} {1}", FirstName, LastName);
                return !string.IsNullOrEmpty(Company) ? string.Format("{0} ({1})", namePart, Company) : namePart;
            }
        }

        [ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
        public byte[] Photo { get; set; }
    }

    [NavigationItem("Marketing")]
    public class Testimonial : XPObject
    {
        
        public Testimonial(Session session) : base(session)
        {
            CreatedOn = DateTime.Now;
        }


        [FieldSize(FieldSizeAttribute.Unlimited)]
        public string Quote;

        [Size(512)]
        public string Highlight { get; set; }


        [VisibleInListView(false)]
        public DateTime CreatedOn { get; set; }

        public string Tags { get; set; }

        [Association("Customer-Testimonials")]
        public Customer Customer { get; set; }
    }
}
