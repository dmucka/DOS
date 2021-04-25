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
   /// Model for Tolerance.
   /// </summary>
   [System.ComponentModel.Description("Model for Tolerance.")]
   public partial class Tolerance
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected Tolerance()
      {
         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static Tolerance CreateToleranceUnsafe()
      {
         return new Tolerance();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="valuename">Target name of Column.</param>
      /// <param name="maxvalue">Target Max Value.</param>
      /// <param name="minvalue">Target Min Value.</param>
      /// <param name="edited">When was Tolerance last edited.</param>
      /// <param name="editedby">User FK</param>
      /// <param name="product">Product FK</param>
      /// <param name="process">Process FK</param>
      public Tolerance(string valuename, decimal maxvalue, decimal minvalue, DateTime edited, global::DOS_DAL.User editedby, global::DOS_DAL.Product product, global::DOS_DAL.Process process)
      {
         if (string.IsNullOrEmpty(valuename)) throw new ArgumentNullException(nameof(valuename));
         this.ValueName = valuename;

         this.MaxValue = maxvalue;

         this.MinValue = minvalue;

         this.Edited = edited;

         if (editedby == null) throw new ArgumentNullException(nameof(editedby));
         this.EditedBy = editedby;

         if (product == null) throw new ArgumentNullException(nameof(product));
         this.Product = product;

         if (process == null) throw new ArgumentNullException(nameof(process));
         this.Process = process;

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="valuename">Target name of Column.</param>
      /// <param name="maxvalue">Target Max Value.</param>
      /// <param name="minvalue">Target Min Value.</param>
      /// <param name="edited">When was Tolerance last edited.</param>
      /// <param name="editedby">User FK</param>
      /// <param name="product">Product FK</param>
      /// <param name="process">Process FK</param>
      public static Tolerance Create(string valuename, decimal maxvalue, decimal minvalue, DateTime edited, global::DOS_DAL.User editedby, global::DOS_DAL.Product product, global::DOS_DAL.Process process)
      {
         return new Tolerance(valuename, maxvalue, minvalue, edited, editedby, product, process);
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
      /// Target name of Column.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Target name of Column.")]
      public string ValueName { get; set; }

      /// <summary>
      /// Required
      /// Target Max Value.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Target Max Value.")]
      public decimal MaxValue { get; set; }

      /// <summary>
      /// Required
      /// Target Min Value.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Target Min Value.")]
      public decimal MinValue { get; set; }

      /// <summary>
      /// Required
      /// When was Tolerance last edited.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("When was Tolerance last edited.")]
      public DateTime Edited { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

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
      /// Required&lt;br/&gt;
      /// Process FK
      /// </summary>
      [Description("Process FK")]
      public virtual global::DOS_DAL.Process Process { get; set; }

   }
}
