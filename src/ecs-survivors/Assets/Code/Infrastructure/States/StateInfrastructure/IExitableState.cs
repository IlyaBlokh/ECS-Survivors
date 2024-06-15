using Cysharp.Threading.Tasks;
using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public interface IExitableState
  {
    UniTask BeginExit();
    void EndExit();
  }
}