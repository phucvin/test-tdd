using System.Collections.Generic;

namespace TestTdd
{
    internal class AcademyUiPure
    {
        internal List<CombinationUiPure> _uiList;

        private List<Combination> _list;

        public AcademyUiPure(List<Combination> list)
        {
            _list = new List<Combination>(list);

            _uiList = new List<CombinationUiPure>();
            foreach (var comb in _list)
            {
                var combUi = createCombinationUi(comb);
                combUi.Academy = this;
                _uiList.Add(combUi);
            }
        }

        public void RefreshAll(CombinationUiPure exceptThis)
        {
            foreach (var combUi in _uiList)
            {
                if (combUi != exceptThis)
                {
                    combUi.Refresh();
                }
            }
        }

        protected virtual CombinationUiPure createCombinationUi(Combination combination)
        {
            return new CombinationUiPure(combination);
        }
    }

    internal class AcademyUi : AcademyUiPure
    {
        public AcademyUi(List<Combination> list) :
            base(list)
        { }

        protected override CombinationUiPure createCombinationUi(Combination combination)
        {
            return new CombinationUi(combination);
        }
    }
}