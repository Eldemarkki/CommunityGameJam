public struct Quest
{
    private Item item1;
    private Item item2;
    private Item result;

    public bool CorrectAnswer { get => IsTrue(); }

    public Quest(Item item1, Item item2, Item result){
        this.item1 = item1;
        this.item2 = item2;
        this.result = result;
    }

    public Quest(Item result){
        this.item1 = result.recipe1;
        this.item2 = result.recipe2;
        this.result = result;
    }

    public string GetText()
    {
        return $"{item1.name} + {item2.name} = {result.name}";
    }

    private bool IsTrue()
    {
        return (result.recipe1 == item1 && result.recipe2 == item2) ||
               (result.recipe1 == item2 && result.recipe2 == item1);
    }
}
