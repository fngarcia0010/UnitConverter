import { useEffect, useState } from "react";

import { API_ENDPOINT } from "./endpoints";
import axios from "axios";
import styles from "./styles/styles.module.css";

type Unit = "" | "length" | "temperature" | "weight";

interface UnitList {
  length: string[];
  temperature: string[];
  weight: string[];
}

interface ConvertionResult {
  unitType: string;
  from: string;
  to: string;
  previousValue: number;
  convertedValue: number;
}

export default function App() {
  const [units, setUnits] = useState<UnitList | null>(null);
  const [selectedUnit, setSelectedUnit] = useState<Unit>("");
  const [selectedUnitValues, setSelectedUnitValues] = useState<string[] | null>();
  const [valueToConvert, setValueToConvert] = useState<number | null>(null);
  const [convertFrom, setConvertFrom] = useState("");
  const [convertTo, setConvertTo] = useState("");
  const [convertionResult, setConvertionResult] = useState<ConvertionResult | null>(null);

  const handleConvertion = async () => {
    try {
      const { data } = await axios.post(`${API_ENDPOINT}/convert`, {
        UnitType: selectedUnit,
        Value: valueToConvert,
        From: convertFrom,
        To: convertTo,
      });

      setConvertionResult(data);
    } catch (error) {
      alert("Error during convertion.");
      console.log(error);
    }
  };

  useEffect(() => {
    const fetchUnits = async () => {
      const storedData = localStorage.getItem("units");
      if (storedData) {
        setUnits(JSON.parse(storedData));
      } else {
        const { data } = await axios.get(`${API_ENDPOINT}/units`);
        setUnits(data);
        localStorage.setItem("units", JSON.stringify(data));
      }
    };

    fetchUnits();
  }, []);

  useEffect(() => {
    if (units && selectedUnit !== "") {
      setSelectedUnitValues(units[selectedUnit]);
    } else {
      setSelectedUnitValues(null);
    }

    setConvertionResult(null);
  }, [selectedUnit]);

  return (
    <div className={styles.root}>
      <div className={styles.header}>
        <h2>Unit Converter</h2>
        <p>
          Convert between units of length, temperature, and weight with ease. This app provides a quick, accurate
          conversion by selecting your unit type and values, with results displayed instantly.
        </p>
      </div>
      <div className={styles.units}>
        {units ? (
          <ul className={styles.unitsContainer}>
            <li>
              <span className={styles.unitName}>Lengths</span>{" "}
              <span className={styles.unitValue}>{units?.length.join(", ")}</span>
            </li>
            <li>
              <span className={styles.unitName}>Temperatures</span>{" "}
              <span className={styles.unitValue}>{units?.temperature.join(", ")}</span>
            </li>
            <li>
              <span className={styles.unitName}>Weights</span>{" "}
              <span className={styles.unitValue}>{units?.weight.join(", ")}</span>
            </li>
          </ul>
        ) : (
          <p>Loading...</p>
        )}
      </div>
      <div className={styles.converter}>
        <div className={styles.selectContainer}>
          <label htmlFor="units">Units</label>
          <select
            id="units"
            onChange={(e: React.ChangeEvent<HTMLSelectElement>) => setSelectedUnit(e.target.value as Unit)}
          >
            <option value="">Select Unit</option>
            <option value="length">Length</option>
            <option value="temperature">Temperature</option>
            <option value="weight">Weight</option>
          </select>
        </div>

        {selectedUnitValues && (
          <>
            <div className={styles.valueContainer}>
              <label htmlFor="value">Value</label>
              <input
                id="value"
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setValueToConvert(Number(e.target.value))}
                type="number"
              />
            </div>

            <div className={styles.convertValue}>
              <label htmlFor="convertFrom">From</label>
              <select
                id="convertFrom"
                onChange={(e: React.ChangeEvent<HTMLSelectElement>) => setConvertFrom(e.target.value)}
              >
                <option value="">Choose value</option>
                {selectedUnitValues && selectedUnitValues.map((u) => <option key={u}>{u}</option>)}
              </select>
            </div>

            <div className={styles.convertValue}>
              <label htmlFor="convertTo">To</label>
              <select
                id="convertTo"
                onChange={(e: React.ChangeEvent<HTMLSelectElement>) => setConvertTo(e.target.value)}
              >
                <option value="">Choose value</option>
                {selectedUnitValues && selectedUnitValues.map((u) => <option key={u}>{u}</option>)}
              </select>
            </div>

            <button className={styles.convertBtn} onClick={handleConvertion}>
              Convert
            </button>
          </>
        )}

        {convertionResult && (
          <div className={styles.result}>
            <span>
              {convertionResult.convertedValue} {convertionResult.to}
            </span>
          </div>
        )}
      </div>
    </div>
  );
}
