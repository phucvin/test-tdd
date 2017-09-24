namespace TestTdd
{
internal class CombinationUiPure
{
    public AcademyUiPure Academy { get; set; }

    internal ItemsTablePure _requirementsTable;
    internal ItemSlotPure _resultSlot;

    private Combination _comb;

    public CombinationUiPure(Combination combination)
    {
        _comb = combination;

        initComponents();
        _requirementsTable.Show(_comb.Requirements);
        _resultSlot.Show(_comb.Result);

        Refresh();
    }

    public void Refresh()
    {
        setCombineButtonEnable(_comb.CanCombine());
    }

    internal void onCombineClick()
    {
        _comb.Combine();
        Refresh();
        if (Academy != null)
        {
            Academy.RefreshAll(this);
        }
    }

    protected virtual void initComponents()
    {
        _requirementsTable = new ItemsTablePure();
        _resultSlot = new ItemSlotPure();
    }

    protected virtual void setCombineButtonEnable(bool enable)
    { }
}

    internal class CombinationUi : CombinationUiPure
    {
        public CombinationUi(Combination combination)
            : base(combination)
        { }

        protected override void initComponents()
        {
            _requirementsTable = new ItemsTable();
            _resultSlot = new ItemSlot();
        }
    }
}