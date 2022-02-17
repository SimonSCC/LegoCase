# Markdown File

[Open question] - Any issues with the data model, and how can we improve it? 

[Open question] - Any other filter options you might think that might be useful?  

The data model could be seperated into more objects, like:
Also a material ID so we don't have to rely on the spelling of the name to identify 
a unique material.

Original:
      "ID": 8,
      "Name": "Polyethylene Terephthalate (PET)",
      "VendorID": 13,
      "Color": "blue green",
      "PricePerUnit": 254,
      "Currency": "DKK",
      "Unit": "lbs",
      "MeltingPoint": 502,
      "TempUnit": "F",
      "DeliveryTimeDays": 17

Could be:

    "ID": 8,
    "Name": "Polyethylene Terephthalate (PET)",
    "VendorID": 13,
    "Color": "blue green",
    "PriceInformation": [
      {
        "PricePerUnit": 254,
        "Currency": "DKK",
        "Unit": "lbs"
      }
    ],
    "MeltingInformation": [
      {
        "MeltingPoint": 502,
        "TempUnit": "F"
      }
    ],
    "DeliveryTimeDays": 17


Further development would include API connection to retrieve actual exchange rates.
Also include in display a uniform value for easier manual comparison.


        

 