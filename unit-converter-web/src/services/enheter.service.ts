const unitTypes = [
  { name: 'Längd📏', unitTypeName: 'length' },
  { name: 'Vikt🪨', unitTypeName: 'weight' },
  { name: 'Volym🧪', unitTypeName: 'volume' },
]

class EnheterService {

  getUnitTypes() {
    return unitTypes;
  }
}

export default new EnheterService();