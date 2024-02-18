using Code.Progress.Data;

namespace Code.Progress.Provider
{
  public class ProgressProvider : IProgressProvider
  {
    public ProgressData ProgressData { get; private set; }

    public void SetProgressData(ProgressData data)
    {
      ProgressData = data;
    }
  }
}