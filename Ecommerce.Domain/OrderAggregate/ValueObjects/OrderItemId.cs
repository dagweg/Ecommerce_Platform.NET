using Ecommerce.Domain.Common.Models;

namespace Ecommerce.Domain.OrderAggregate.ValueObjects;

public sealed class OrderItemId : ValueObject
{
  public Guid Value { get; } = Empty;

  public static OrderItemId Empty => new();

  private OrderItemId(Guid value)
  {
    Value = value;
  }

  public static OrderItemId CreateUnique() => new(Guid.NewGuid());

  public static implicit operator Guid(OrderItemId self) => self.Value;

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }

  private OrderItemId() { }
}