import { useEffect, useState } from "react";
import axios from "axios";

import styles from "./styles/styles.module.css";

interface UnitList {
  length: string[];
  temperature: string[];
  weight: string[];
}

type Unit = "" | "length" | "temperature" | "weight";

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
  const [selectedUnitValues, setSelectedUnitValues] = useState<
    string[] | null
  >();
  const [valueToConvert, setValueToConvert] = useState<number | null>(null);
  const [convertFrom, setConvertFrom] = useState("");
  const [convertTo, setConvertTo] = useState("");
  const [convertionResult, setConvertionResult] =
    useState<ConvertionResult | null>(null);

  const handleConvertion = async () => {
    try {
      const { data } = await axios.post("http://localhost:5000/convert", {
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
        const { data } = await axios.get("http://localhost:5000/units");
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
  }, [selectedUnit]);

  console.log(selectedUnitValues);

  return (
    <div className={styles.root}>
      <div className={styles.header}>
        <h2>Unit Converter</h2>
        <p>
          This unit converter is cool. This unit converter is cool. This unit
          converter is cool.
        </p>
      </div>
      <div className={styles.units}>
        {units ? (
          <ul>
            <li>
              <span className={styles.unitName}>Length</span>{" "}
              <span className={styles.unitValue}>
                {units?.length.join(", ")}
              </span>
            </li>
            <li>
              <span className={styles.unitName}>Temperature</span>{" "}
              <span className={styles.unitValue}>
                {units?.temperature.join(", ")}
              </span>
            </li>
            <li>
              <span className={styles.unitName}>Weigth</span>{" "}
              <span className={styles.unitValue}>
                {units?.weight.join(", ")}
              </span>
            </li>
          </ul>
        ) : (
          <p>Loading...</p>
        )}
      </div>
      <div className={styles.converter}>
        <div>
          <select
            onChange={(e: React.ChangeEvent<HTMLSelectElement>) =>
              setSelectedUnit(e.target.value as Unit)
            }
          >
            <option value="">Select Unit</option>
            <option value="length">Length</option>
            <option value="temperature">Temperature</option>
            <option value="weight">Weight</option>
          </select>
        </div>
        <div>
          <h3>Convert from</h3>
          {selectedUnitValues && (
            <select
              onChange={(e: React.ChangeEvent<HTMLSelectElement>) =>
                setConvertFrom(e.target.value)
              }
            >
              <option value="">Choose value</option>
              {selectedUnitValues &&
                selectedUnitValues.map((u) => <option key={u}>{u}</option>)}
            </select>
          )}
        </div>
        <div>
          <h3>Value</h3>
          <input
            onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
              setValueToConvert(Number(e.target.value))
            }
            type="number"
          />
        </div>
        <div>
          <h3>Convert To</h3>
          {selectedUnitValues && (
            <select
              onChange={(e: React.ChangeEvent<HTMLSelectElement>) =>
                setConvertTo(e.target.value)
              }
            >
              <option value="">Choose value</option>
              {selectedUnitValues &&
                selectedUnitValues.map((u) => <option key={u}>{u}</option>)}
            </select>
          )}
        </div>

        <button onClick={handleConvertion}>Convert!</button>

        {convertionResult && (
          <div>
            <h3>Result</h3>
            <p>
              {convertionResult.convertedValue} {convertionResult.to}
            </p>
          </div>
        )}
      </div>
    </div>
  );
}
