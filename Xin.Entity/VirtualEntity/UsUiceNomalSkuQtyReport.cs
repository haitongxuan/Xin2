using System;
using System.Collections.Generic;
using System.Text;

namespace Xin.Entities.VirtualEntity
{
    public class UsUiceNomalSkuQtyReport
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Required()]
        public virtual int Id
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Sku
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string CategoryParent
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Category
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Picture
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.StringLength(255)]
        public virtual string Name
        {
            get;
            set;
        }

        public virtual int? UnicePeriodQty
        {
            get;
            set;
        }

        public virtual int? UncieToUsQty
        {
            get;
            set;
        }

        public virtual int? DhToUsQty
        {
            get;
            set;
        }

        public virtual int? UniceSaleQty
        {
            get;
            set;
        }

        public virtual int? UsTransAmazingQty
        {
            get;
            set;
        }

        public virtual int? OffLineQty
        {
            get;
            set;
        }

        public virtual int? UniceEndingQty
        {
            get;
            set;
        }

        public virtual int? UsEndingQty
        {
            get;
            set;
        }

        public virtual int? NomalEnndingQty
        {
            get;
            set;
        }
    }
}
