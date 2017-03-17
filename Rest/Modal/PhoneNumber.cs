﻿namespace Rest.Modal
{
    public class PhoneNumber
    {
        public NumberTypeValue NumberTypeValue { get; set; }
        public bool IsSystem { get; set; }
        public int PersonId { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public string NumberFormatted { get; set; }
        public string Extension { get; set; }
        public int NumberTypeValueId { get; set; }
        public bool IsMessagingEnabled { get; set; }
        public bool IsUnlisted { get; set; }
        public object Description { get; set; }
        public string NumberFormattedWithCountryCode { get; set; }
        public string CreatedDateTime { get; set; }
        public string ModifiedDateTime { get; set; }
        public int CreatedByPersonAliasId { get; set; }
        public int? ModifiedByPersonAliasId { get; set; }
        public bool ModifiedAuditValuesAlreadyUpdated { get; set; }
        public object Attributes { get; set; }
        public object AttributeValues { get; set; }
        public int Id { get; set; }
        public string Guid { get; set; }
        public object ForeignId { get; set; }
        public object ForeignGuid { get; set; }
        public object ForeignKey { get; set; }
    }

    public class NumberTypeValue
    {
        public bool IsSystem { get; set; }
        public int DefinedTypeId { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public object CreatedDateTime { get; set; }
        public object ModifiedDateTime { get; set; }
        public object CreatedByPersonAliasId { get; set; }
        public object ModifiedByPersonAliasId { get; set; }
        public bool ModifiedAuditValuesAlreadyUpdated { get; set; }
        public object Attributes { get; set; }
        public object AttributeValues { get; set; }
        public int Id { get; set; }
        public string Guid { get; set; }
        public object ForeignId { get; set; }
        public object ForeignGuid { get; set; }
        public object ForeignKey { get; set; }
    }
}