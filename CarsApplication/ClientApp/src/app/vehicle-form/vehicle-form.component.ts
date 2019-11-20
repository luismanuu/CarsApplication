import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';


@Component({
    selector: 'app-vehicle-form',
    templateUrl: './vehicle-form.component.html',
    styleUrls: ['./vehicle-form.component.css']
})
/** vehicle-form component*/
export class VehicleFormComponent implements OnInit {
/** vehicle-form ctor */
  makes: any;
  vehicle: any = {};
  models: any;
  features: any;
  constructor(private vehicleService: VehicleService) {

  }

  ngOnInit() {
    //trae todos los makes
    this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
    this.vehicleService.getFeatures().subscribe(features => this.features = features)
  }

  onMakeChange() {
    //identifica que make se escoge en el select
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    //trae los modelos del make escogido
    this.models = selectedMake ? selectedMake.models : [];
  }
}
