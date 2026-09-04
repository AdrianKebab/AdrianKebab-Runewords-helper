using CommunityToolkit.Mvvm.ComponentModel;

public partial class OwnedRune : ObservableObject
{
    [ObservableProperty]
    private Rune? rune;

    [ObservableProperty]
    private int amount;
}