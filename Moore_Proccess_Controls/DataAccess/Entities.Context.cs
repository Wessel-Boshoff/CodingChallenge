﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Moore_Proccess_ControlsEntities : DbContext
    {
        public Moore_Proccess_ControlsEntities()
            : base("name=Moore_Proccess_ControlsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int InsertLog(Nullable<int> idLevel, string message)
        {
            var idLevelParameter = idLevel.HasValue ?
                new ObjectParameter("IdLevel", idLevel) :
                new ObjectParameter("IdLevel", typeof(int));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertLog", idLevelParameter, messageParameter);
        }
    
        public virtual int InsertCalculationResult(Nullable<int> idTag, Nullable<int> idCalculationType, Nullable<decimal> value)
        {
            var idTagParameter = idTag.HasValue ?
                new ObjectParameter("IdTag", idTag) :
                new ObjectParameter("IdTag", typeof(int));
    
            var idCalculationTypeParameter = idCalculationType.HasValue ?
                new ObjectParameter("IdCalculationType", idCalculationType) :
                new ObjectParameter("IdCalculationType", typeof(int));
    
            var valueParameter = value.HasValue ?
                new ObjectParameter("Value", value) :
                new ObjectParameter("Value", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertCalculationResult", idTagParameter, idCalculationTypeParameter, valueParameter);
        }
    
        public virtual ObjectResult<SelectCalculationType_Result> SelectCalculationType()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectCalculationType_Result>("SelectCalculationType");
        }
    
        public virtual ObjectResult<SelectTag_Result> SelectTag()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectTag_Result>("SelectTag");
        }
    }
}