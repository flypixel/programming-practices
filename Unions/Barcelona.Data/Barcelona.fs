namespace Barcelona.Data

open System

type BarcelonaCity(id: string, name: string, zipcode: string, smartLoc: string, country: string, latitude: decimal, longitude: decimal) =
    member val Id = id with get
    member val Name = name with get
    member val Zipcode = zipcode with get
    member val SmartLoc = smartLoc with get
    member val Country = country with get
    member val Latitude = latitude with get
    member val Longitude = longitude with get