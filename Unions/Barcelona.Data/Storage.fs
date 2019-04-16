namespace Barcelona.Data

open FSharp.Data
open System
type internal Barsa1 = CsvProvider<"./Barcelona1.csv", IgnoreErrors=true, Encoding="UTF-8">
type internal Barsa2 = CsvProvider<"./Barcelona2.csv", IgnoreErrors=true, Encoding="UTF-8">

[<AbstractClass; Sealed>]
type public Storage =

    static member toDecimal (x: float) = if Double.IsNaN(x) then decimal 0.0 else decimal x

    static member public GetBarcelona1() =
        let data = Barsa1.GetSample()
        data.Rows |> Seq.map (fun x -> BarcelonaCity(x.Id.ToString(), x.Name, x.Zipcode.ToString(), x.Smart_location, x.Country, x.Latitude, x.Longitude))
        |> Seq.toArray

    static member public GetBarcelona2() =
        let data = Barsa2.GetSample()
        data.Rows |> Seq.map (fun x -> BarcelonaCity(x.Listing_url, x.Name, x.Zipcode, x.Smart_location, x.Country, Storage.toDecimal(x.Latitude), Storage.toDecimal(x.Longitude)))
        |> Seq.toArray

