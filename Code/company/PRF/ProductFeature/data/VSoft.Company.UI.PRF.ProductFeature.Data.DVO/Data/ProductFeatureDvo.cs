using System;

namespace VSoft.Company.UI.PRF.ProductFeature.Data.DVO.Data
{
    public class ProductFeatureDvo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        public int ProductId { get; set; }
        public double Price { get; set; }


        //public string Name { get; set; } = null!;

        //public string Phone { get; set; } = null!;

        //public string Email { get; set; } = null!;

        //public string? Address { get; set; }

        ///// <summary>
        ///// True: Male, False: Female
        ///// </summary>
        //public bool? Gender { get; set; }

        //public int? PriorityId { get; set; }

        //// public long? ProductFeatureInfoId { get; set; }

      
        public override string ToString()
        {
            return $"{Id} / {Name}";
        }
    }
}
