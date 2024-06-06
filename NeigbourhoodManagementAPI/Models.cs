namespace NeigbourhoodManagementAPI
{
        public class Models
        {
            public class ComplaintForm
            {
                public enum Category
                {
                    Maintenance = 0,
                    Parking = 1,
                    Animals = 2,
                    Children = 3
                }

                public enum Status
                {
                    Pending = 0,
                    Active = 1,
                    Resolved = 2,
                    Cancelled = 3
                }

                public string Id { get; set; }
                public string NameOfAuthor { get; set; }
                public int BuildingNumberOfAuthor { get; set; }
                public int ApartmentNumberOfAuthor { get; set; }
                public string Description { get; set; }
                public int BuildingNumberOfComplaint { get; set; }
                public int ApartmentNumberOfComplaint { get; set; }
                public Category ComplaintCategory { get; set; }
                public Status ComplaintStatus { get; set; }
                public DateTime DateAdded { get; set; }
            }

        }

}
