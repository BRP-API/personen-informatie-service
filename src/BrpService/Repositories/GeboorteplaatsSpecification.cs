﻿using HaalCentraal.BrpService.Generated;
using System.Linq.Expressions;

namespace HaalCentraal.BrpService.Repositories;

public class GeboorteplaatsSpecification : Specification<GbaPersoon>
{
    private readonly string _geboorteplaats;

    public GeboorteplaatsSpecification(string geboorteplaats)
    {
        _geboorteplaats = geboorteplaats;
    }

    public override Expression<Func<GbaPersoon, bool>> ToExpression()
    {
        return persoon => persoon != null && persoon.Geboorte != null && persoon.Geboorte.Plaats != null && string.Compare(persoon.Geboorte.Plaats.Omschrijving, _geboorteplaats, true) == 0;
    }
}
