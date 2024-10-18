import { useEffect, useState } from "react";
import styles from "./styles/styles.module.css";
import axios from "axios";

interface UnitList {
  length: string[];
  weight: string[];
  temperature: string[];
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const UNITS = {
  length: ["mm", "cm", "m", "km", "in", "ft", "yd", "mi"],
  weight: ["g", "kg", "t", "lb", "oz"],
  temperature: ["C", "F", "K"],
};

function App() {
  const [units, setUnits] = useState<UnitList | null>(null);

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

  return (
    <div className={styles.root}>
      <div className={styles.pageBackground}>
        <div className={styles.mobileContainer}>
          <h2 className={styles.title}>Unit Converter</h2>
          <div className={styles.units}>
            <ul className={styles.unitsList}>
              {units ? (
                <>
                  <li>
                    Lengths:{" "}
                    {units?.length?.map((u) => (
                      <span key={u}>{u}, </span>
                    ))}
                  </li>
                  <li>
                    Weights:{" "}
                    {units?.weight?.map((u) => (
                      <span key={u}>{u}, </span>
                    ))}
                  </li>
                  <li>
                    Temperatures:{" "}
                    {units?.temperature?.map((u) => (
                      <span key={u}>{u}, </span>
                    ))}
                  </li>
                </>
              ) : (
                <li>Loading units..</li>
              )}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
