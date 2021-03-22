public interface ITask
{
    string GetTitle();
    string GetDescription();

    void Complete(bool value = true);
}
