﻿using Amazon.DynamoDBv2.DataModel;

namespace RoleRightApp.Repositories;

[DynamoDBTable("role")]
public class Role
{
    [DynamoDBHashKey("roleId")]
    public string RoleId { get; set; }
    
    [DynamoDBProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    
    [DynamoDBProperty("description")]
    public string Description { get; set; }
    
    [DynamoDBProperty("hierarchy")]
    public string Hierarchy { get; set; }
    
    [DynamoDBProperty("rights")]
    public List<string> Rights { get; set; }
    
    [DynamoDBProperty("translationKey")]
    public string TranslationKey { get; set; }
}