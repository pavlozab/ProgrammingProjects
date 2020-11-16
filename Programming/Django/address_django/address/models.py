from django.db import models


class Address(models.Model):
    address_line = models.CharField(max_length=50)    # fix validation  (=
    postal_code = models.IntegerField()
    country = models.CharField(max_length=40)
    city = models.CharField(max_length=40)
    fax_number = models.CharField(max_length=17)
    phone_number = models.CharField(max_length=17)
