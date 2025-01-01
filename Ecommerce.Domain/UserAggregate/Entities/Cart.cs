namespace Ecommerce.Domain.UserAggregate.Entities;

using Ecommerce.Domain.Common.Models;
using Ecommerce.Domain.UserAggregate.ValueObjects;

public class Cart : Entity<CartId>
{
  private readonly List<CartItem> _items = [];

  public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

  private Cart()
    : base(CartId.CreateUnique()) { }

  private Cart(CartId cartId)
    : base(cartId) { }

  public static Cart Create(CartId cartId)
  {
    return new Cart(cartId);
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }
}