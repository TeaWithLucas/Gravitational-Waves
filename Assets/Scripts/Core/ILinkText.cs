namespace Game.Core {
    public interface ILinkText {
        string LinkID { get; }

        string GetLinkDescription();
        string GetLinkName();
    }
}