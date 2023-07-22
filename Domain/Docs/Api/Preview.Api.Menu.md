# Create Menu Request
$hostId = 9940548e-dadc-405f-83f9-57431685cf5d
`POST /hosts/{hostId}/menus`

```
{
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "sections": [
    {
      "name": "Appetizers",
      "description": "Starters",
      "menuItems": [
        {
          "name": "Fried Pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ]
}
```

# Create Menu Respone

`201 `


```
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Yummy Menu",
    "description": "A menu with yummy food",
    "averageRating": 4.5,
    "sections": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                {
                    "id": { "value": "00000000-0000-0000-0000-000000000000" },
                    "name": "Fried Pickles",
                    "description": "Deep fried pickles"
                }
            ]
        }
    ],
    "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
    "dinnerIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "menuReviewIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}

```

