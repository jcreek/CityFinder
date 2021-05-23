# CityFinder

A small console application to find a city from a country code and zip/postal code. This was completed for the Code2Gether community June Challenge in 2021.

## Required configuration

To get this running, specify your own Google API key in the `GoogleMapsGeocodeApiKey` property in `appsettings.json`. You can get this by visiting [the Google APIs website](https://console.cloud.google.com/apis/library/geocoding-backend.googleapis.com).

Otherwise, it's just a standard console application.

## Instructions for use

Enter a valid country code and a zip/postal code and it should tell you which city/town/village that zip/postal code is in.
