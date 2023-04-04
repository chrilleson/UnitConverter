import { UnitModel } from '../models/unit-types';
import http from './http.service';

const unitTypes = [
  { name: 'Längd📏', unitTypeName: 'length' },
  { name: 'Vikt🪨', unitTypeName: 'weight' },
  { name: 'Volym🧪', unitTypeName: 'volume' },
]

class EnheterService {

  getUnitTypes() {
    return unitTypes;
  }

  async getLengthUnits() {
    return await http.get<UnitModel[]>('/length');
  }

  async getWeightUnits() {
    return await http.get<UnitModel[]>('/weight');
  }

  async getVolumeUnits() {
    return await http.get<UnitModel[]>('/volume');
  }
}

export default new EnheterService();