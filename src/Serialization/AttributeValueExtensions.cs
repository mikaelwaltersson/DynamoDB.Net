using Amazon.DynamoDBv2.Model;

namespace DynamoDB.Net.Serialization;

/// <summary>
/// Extension methods for <see cref="AttributeValue"/> instances.
/// </summary>
public static class AttributeValueExtensions
{
    /// <summary>
    /// Returns true when the AttributeValue represents no value (all fields unset).
    /// </summary>
    public static bool IsEmpty(this AttributeValue value) =>
        value is
        {
            NULL: null or false,
            IsBOOLSet: false,
            S: null,
            N: null,
            B: null,
            SS: null or { Count: 0 },
            NS: null or { Count: 0 },
            BS: null or { Count: 0 },
            IsLSet: false,
            IsMSet: false
        };

    /// <summary>
    /// Returns true when the AttributeValue is explicitly NULL or otherwise empty.
    /// </summary>
    public static bool IsEmptyOrNull(this AttributeValue value) =>
        value.NULL is true || value.IsEmpty();

    internal static AttributeValue EnsureIsMSet(this AttributeValue value) =>
        !value.IsMSet
        ? new AttributeValue { IsMSet = true }
        : value;
}
