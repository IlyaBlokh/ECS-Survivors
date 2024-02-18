using Code.Progress.Data;

namespace Code.Progress.Provider
{
  public interface IProgressProvider
  {
    ProgressData ProgressData { get; }
    void SetProgressData(ProgressData data);
  }
}