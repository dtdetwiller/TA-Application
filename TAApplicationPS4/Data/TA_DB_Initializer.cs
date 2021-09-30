using System;
using System.Linq;
using TAApplicationPS4.Models;

namespace TAApplicationPS4.Data
{
    public class TA_DB_Initializer
    {

        public static void Initialize(TA_DB db)
        {
            // This makes sure that the database has been created.
            db.Database.EnsureCreated();

            if (db.Applications.Any())
                return; // DB has been seeded.

            var applicaitons = new Application[]
            {
                // Create seeded data
                new Application{Name="Daniel Detwiller",uID="u1148322",Program="CS",GPA=3.7f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Billy Bob",uID="u2930495",Program="CS",GPA=3.2f,Hours=15,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Michelob Ultra",uID="u0293845",Program="CS",GPA=3.9f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Malibu Wake Setter",uID="u2293342",Program="CS",GPA=4.0f,Hours=25,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Happy Dad",uID="u118332",Program="CS",GPA=2.8f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Noah Gottlieb",uID="u9299933",Program="ENTP",GPA=3.1f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Kyle Lautt",uID="u2232232",Program="MKTH",GPA=3.3f,Hours=15,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="James Bricker",uID="u9291122",Program="ECON",GPA=3.5f,Hours=15,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Ben Sky",uID="u0708822",Program="ETHNC",GPA=4.0f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."},
                new Application{Name="Thomas Detwiller",uID="u1122345",Program="CHEM",GPA=3.9f,Hours=20,Phone="(603) 717-5221",Email="email123@gmail.com",Degree="BS",LinkedInURL="https://www.linkedin.com/",
                    PersonalStatement="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque egestas nisl a justo porttitor hendrerit. " +
                    "Morbi imperdiet eu mauris sed egestas. Integer rhoncus auctor nisi sed ornare. Integer non sagittis leo, vitae tempus quam. Cras " +
                    "consequat ante sed magna sodales, sed mollis velit placerat. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec bibendum non massa at volutpat."}
            };

            foreach (Application a in applicaitons)
                db.Applications.Add(a);

            // Save the changes to the database.
            db.SaveChanges();
        }
    }
}
