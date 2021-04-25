//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.4.7
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DOS_DAL
{
   /// <summary>
   /// Model for Order.
   /// </summary>
   [System.ComponentModel.Description("Model for Order.")]
   public partial class Order
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Order()
      {
         ManufacturingSteps = new System.Collections.Generic.HashSet<global::DOS_DAL.ManufacturingStep>();

         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Order CreateOrderUnsafe()
      {
         return new Order();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="status">Status of order.</param>
      /// <param name="serialnumber">Serial Number of order.</param>
      /// <param name="customer">Customer of order.</param>
      /// <param name="created">When was Order Created.</param>
      /// <param name="edited">When was Order last Edited.</param>
      /// <param name="isdeleted">Soft deleted flag.</param>
      /// <param name="createdby">User FK</param>
      /// <param name="editedby">User FK</param>
      /// <param name="product">Product FK</param>
      public Order(string status, string serialnumber, string customer, DateTime created, DateTime edited, bool isdeleted, global::DOS_DAL.User createdby, global::DOS_DAL.User editedby, global::DOS_DAL.Product product)
      {
         if (string.IsNullOrEmpty(status)) throw new ArgumentNullException(nameof(status));
         this.Status = status;

         if (string.IsNullOrEmpty(serialnumber)) throw new ArgumentNullException(nameof(serialnumber));
         this.SerialNumber = serialnumber;

         if (string.IsNullOrEmpty(customer)) throw new ArgumentNullException(nameof(customer));
         this.Customer = customer;

         this.Created = created;

         this.Edited = edited;

         this.IsDeleted = isdeleted;

         if (createdby == null) throw new ArgumentNullException(nameof(createdby));
         this.CreatedBy = createdby;

         if (editedby == null) throw new ArgumentNullException(nameof(editedby));
         this.EditedBy = editedby;

         if (product == null) throw new ArgumentNullException(nameof(product));
         this.Product = product;

         this.ManufacturingSteps = new System.Collections.Generic.HashSet<global::DOS_DAL.ManufacturingStep>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="status">Status of order.</param>
      /// <param name="serialnumber">Serial Number of order.</param>
      /// <param name="customer">Customer of order.</param>
      /// <param name="created">When was Order Created.</param>
      /// <param name="edited">When was Order last Edited.</param>
      /// <param name="isdeleted">Soft deleted flag.</param>
      /// <param name="createdby">User FK</param>
      /// <param name="editedby">User FK</param>
      /// <param name="product">Product FK</param>
      public static Order Create(string status, string serialnumber, string customer, DateTime created, DateTime edited, bool isdeleted, global::DOS_DAL.User createdby, global::DOS_DAL.User editedby, global::DOS_DAL.Product product)
      {
         return new Order(status, serialnumber, customer, created, edited, isdeleted, createdby, editedby, product);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// Unique identifier
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Unique identifier")]
      public int Id { get; set; }

      /// <summary>
      /// Required, Max length = 255
      /// Status of order.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Status of order.")]
      public string Status { get; set; }

      /// <summary>
      /// Indexed, Required, Max length = 255
      /// Serial Number of order.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Serial Number of order.")]
      public string SerialNumber { get; set; }

      /// <summary>
      /// Required, Max length = 255
      /// Customer of order.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Customer of order.")]
      public string Customer { get; set; }

      /// <summary>
      /// Max length = 1023
      /// Notes for order.
      /// </summary>
      [MaxLength(1023)]
      [StringLength(1023)]
      [System.ComponentModel.Description("Notes for order.")]
      public string Notes { get; set; }

      /// <summary>
      /// Required
      /// When was Order Created.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("When was Order Created.")]
      public DateTime Created { get; set; }

      /// <summary>
      /// Required
      /// When was Order last Edited.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("When was Order last Edited.")]
      public DateTime Edited { get; set; }

      /// <summary>
      /// Required
      /// Soft deleted flag.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Soft deleted flag.")]
      public bool IsDeleted { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required&lt;br/&gt;
      /// User FK
      /// </summary>
      [Description("User FK")]
      public virtual global::DOS_DAL.User CreatedBy { get; set; }

      /// <summary>
      /// Required&lt;br/&gt;
      /// User FK
      /// </summary>
      [Description("User FK")]
      public virtual global::DOS_DAL.User EditedBy { get; set; }

      /// <summary>
      /// Required&lt;br/&gt;
      /// Product FK
      /// </summary>
      [Description("Product FK")]
      public virtual global::DOS_DAL.Product Product { get; set; }

      /// <summary>
      /// Collection of ManufacturingSteps
      /// </summary>
      [Description("Collection of ManufacturingSteps")]
      public virtual ICollection<global::DOS_DAL.ManufacturingStep> ManufacturingSteps { get; private set; }

   }
}
