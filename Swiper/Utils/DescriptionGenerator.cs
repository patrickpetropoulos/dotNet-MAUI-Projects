using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiper.Utils;
public class DescriptionGenerator
{
  private string[] _adjectives = { "nice", "horrible", "great", "terribly old", "brand new" };
  private string[] _other = { "picture of grandpa", "car", "photo of a forest", "duck" };

  private static Random random = new();

  public string Generate()
  {
    var adjective = _adjectives[random.Next(_adjectives.Length)];
    var other = _other[random.Next(_other.Length)];
    return $"A {adjective} {other}";
  }
}
