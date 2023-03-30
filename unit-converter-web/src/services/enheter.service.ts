const unitTypes = [
  'Längd',
  'Vikt',
  'Volym'
]

class EnheterService {

  getUnitTypes() {
    return unitTypes;
  }
}

export default new EnheterService();