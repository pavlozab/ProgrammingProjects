# Generated by Django 3.1.3 on 2020-12-09 17:29

from django.conf import settings
import django.core.validators
from django.db import migrations, models
import django.db.models.deletion
import modules.address.validation



class Migration(migrations.Migration):

    initial = True

    dependencies = [
        migrations.swappable_dependency(settings.AUTH_USER_MODEL),
    ]

    operations = [
        migrations.CreateModel(
            name='Address',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('address_line', models.CharField(max_length=50, validators=[modules.address.validation.Validation.symbolValidation])),
                ('postal_code', models.CharField(max_length=5, validators=[django.core.validators.RegexValidator(message='Postal code must be contains exactly 5 digits', regex='^\\d{5}$')])),
                ('country', models.CharField(max_length=50, validators=[modules.address.validation.Validation.symbolValidation])),
                ('city', models.CharField(max_length=50, validators=[modules.address.validation.Validation.symbolValidation])),
                ('fax_number', models.CharField(max_length=13, validators=[modules.address.validation.Validation.numberValidation])),
                ('phone_number', models.CharField(max_length=13, validators=[modules.address.validation.Validation.numberValidation])),
                ('amount', models.PositiveIntegerField(default=0)),
                ('user', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL, verbose_name='User ')),
            ],
        ),

        migrations.CreateModel(
            name='Orders',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('amount', models.PositiveIntegerField()),
                ('date', models.DateTimeField(auto_now_add=True, verbose_name='date')),
                ('item', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to='address.address', verbose_name='address')),
                ('user', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL, verbose_name='User ')),
            ],
        ),
    ]


