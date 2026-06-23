using HaalCentraal.BrpService.Generated;

namespace HaalCentraal.BrpService.Repositories;

public static class PersonenQueryExtensions
{
    private static Specification<T> AndGemeenteVanInschrijvingSpecification<T>(this Specification<T> specification, string? gemeenteVanInschrijving) where T : IPersonenQueryParameters
    {
        if (!string.IsNullOrWhiteSpace(gemeenteVanInschrijving))
        {
            return specification.And(new GemeenteVanInschrijvingSpecification<T>(gemeenteVanInschrijving));
        }
        return specification;
    }

    public static Specification<GbaPersoonBeperkt> ToSpecification(this ZoekMetGeslachtsnaamEnGeboortedatumFilter query)
    {
        var specification = new GeslachtsnaamSpecification(query.Geslachtsnaam)
            .And(new GeboorteDatumSpecification(query.Geboortedatum));

        if (!string.IsNullOrWhiteSpace(query.Voornamen))
        {
            specification = specification.And(new VoornamenSpecification(query.Voornamen));
        }
        if(!string.IsNullOrWhiteSpace(query.Voorvoegsel))
        {
            specification = specification.And(new VoorvoegselSpecification(query.Voorvoegsel));
        }
        if(!string.IsNullOrWhiteSpace(query.Geslachtsaanduiding))
        {
            specification = specification.And(new GeslachtSpecification(query.Geslachtsaanduiding));
        }
        specification = specification.And(new InclusiefOverledenPersonenSpecification(query.InclusiefOverledenPersonen));
        specification = specification.AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);

        return specification;
    }

    public static Specification<GbaPersoon> ToSpecification(this RaadpleegMetBurgerservicenummer query)
    {
        return new BsnSpecification(query.Burgerservicenummer)
            .AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);
    }

    public static Specification<GbaPersoonBeperkt> ToSpecification(this ZoekMetPostcodeEnHuisnummerFilter query)
    {
        var specification = new PostcodeSpecification(query.Postcode)
            .And(new HuisnummerSpecification(query.Huisnummer));

        if (!string.IsNullOrWhiteSpace(query.Huisletter))
        {
            specification = specification.And(new HuisletterSpecification(query.Huisletter));
        }
        if (!string.IsNullOrWhiteSpace(query.Huisnummertoevoeging))
        {
            specification = specification.And(new HuisnummertoevoegingSpecification(query.Huisnummertoevoeging));
        }
        if(query.Geboortedatum.HasValue)
        {
            specification = specification.And(new GeboorteDatumSpecification(query.Geboortedatum.Value));
        }
        if (!string.IsNullOrWhiteSpace(query.Geslachtsnaam))
        {
            specification = specification.And(new GeslachtsnaamSpecification(query.Geslachtsnaam));
        }
        specification = specification.And(new InclusiefOverledenPersonenSpecification(query.InclusiefOverledenPersonen));
        specification = specification.AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);

        return specification;
    }

    public static Specification<GbaPersoonBeperkt> ToSpecification(this ZoekMetNaamEnGemeenteVanInschrijvingFilter query)
    {
        var specification = new GeslachtsnaamSpecification(query.Geslachtsnaam)
            .And(new VoornamenSpecification(query.Voornamen))
            .AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);

        if (!string.IsNullOrWhiteSpace(query.Voorvoegsel))
        {
            specification = specification.And(new VoorvoegselSpecification(query.Voorvoegsel));
        }
        if (!string.IsNullOrWhiteSpace(query.Geslachtsaanduiding))
        {
            specification = specification.And(new GeslachtSpecification(query.Geslachtsaanduiding));
        }
        specification = specification.And(new InclusiefOverledenPersonenSpecification(query.InclusiefOverledenPersonen));

        return specification;
    }

    public static Specification<GbaPersoonBeperkt> ToSpecification(this ZoekMetNummeraanduidingIdentificatie query)
    {
        return
            new NummeraanduidingIdentificatieSpecification(query.NummeraanduidingIdentificatie)
            .And(new InclusiefOverledenPersonenSpecification(query.InclusiefOverledenPersonen))
            .AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);
    }

    public static Specification<GbaGezagPersoonBeperkt> ToSpecification(this ZoekMetAdresseerbaarObjectIdentificatie query)
    {
        return
            new AdresseerbaarObjectIdentificatieSpecification(query.AdresseerbaarObjectIdentificatie)
            .And(new InclusiefOverledenGezagPersonenSpecification(query.InclusiefOverledenPersonen))
            .AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);
    }

    public static Specification<GbaPersoonBeperkt> ToSpecification(this ZoekMetStraatHuisnummerEnGemeenteVanInschrijving query)
    {
        Specification<GbaPersoonBeperkt> specification = new StraatSpecification(query.Straat)
            .And(new HuisnummerSpecification(query.Huisnummer!.Value))
            .AndGemeenteVanInschrijvingSpecification(query.GemeenteVanInschrijving);

        if (!string.IsNullOrWhiteSpace(query.Huisletter))
        {
            specification = specification.And(new HuisletterSpecification(query.Huisletter));
        }
        if (!string.IsNullOrWhiteSpace(query.Huisnummertoevoeging))
        {
            specification = specification.And(new HuisnummertoevoegingSpecification(query.Huisnummertoevoeging));
        }
        specification = specification.And(new InclusiefOverledenPersonenSpecification(query.InclusiefOverledenPersonen));

        return specification;
    }
}
