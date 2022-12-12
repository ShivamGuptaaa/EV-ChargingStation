import React, { useEffect, useState } from "react";
import { h } from "gridjs";
import { Grid } from "gridjs-react";
import { Card, Modal } from "react-bootstrap";

export default function List() {
  const [time, setTime] = useState();
  const [usingStation, setUsingStation] = useState("None");
  const [receipt, setReceipt] = useState({
    data:{id: "",
    siteId: 0,
    siteName: "",
    totalAmount: 0,
    ratePerMinute: 0,
    totalTime: 0}
    
  });
  const [show, setShow] = useState(false);
  const classNames = {
    table: "table",
    pagination: "d-flex justify-content-around",
    search: "search-field",
  };
  const startFunction = (id,name) => {
    setUsingStation(name);
    alert(name+"'s socket is UNLOCKED"+", Your timer has been started");
    fetch(`https://localhost:5001/chargingstation/UnlockChargingStation`,{
      method: 'POST',
      body: JSON.stringify({
        siteId: id
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    })
       .catch((err) => {
          console.log(err.message);
       });
       setTime(new Date());
  };

  const stopFunction = (val,e) => {
    const totalTime =  Date.parse(new Date())- Date.parse(time) ;
    const minutes = Math.floor((totalTime/1000/60)%60);
    setUsingStation("None");
    console.log(e);
    fetch(`https://localhost:5001/ChargingStation/CompleteCharging`,{
      method: 'POST',
      body: JSON.stringify({
        minutesConsumed: minutes,
        siteId: val
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    })
    .then((response) => response.json()
   )
       .then((data) => {
          // Handle data
          setReceipt({...receipt, data});
          setShow(true);
       })
       .catch((err) => {
          console.log(err.message);
       });

      
  };
  const [stations, setStations] = useState([]);

  useEffect(() => {
    const url = "https://localhost:5001/chargingstation/";

    const fetchData = async () => {
      try {
        const response = await fetch(url);
        const json = await response.json();
        setStations(json);
      } catch (error) {
        console.log("error", error);
      }
    };

    fetchData();
    setShow(false);
}, []);
const handleCancel = () => {
  setShow(false);
};
  return (
    <>
    <Modal size="lg" show={show} onHide={handleCancel} centered>
        <Modal.Header closeButton>
          <Modal.Title>
            <span>Receipt</span>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div
            className="border p-2 rounded rounded-10"
            style={{ backgroundColor: "#E1F5FE" }}
          >
            Your Receipt has been created... <br />
            <br />
            <b className="mt-2">Receipt Id : </b> {receipt.data.id}
            <br/>
            <b className="mt-2">Site Name : </b> {receipt.data.siteName}
            <br/>
            <b className="mt-2">Time Consumed : </b> {receipt.data.totalTime}
            <br />
            <b className="mt-2">Rate/Minute : </b> {receipt.data.ratePerMinute}
            <br />
            <h2 className="mt-2">Total Amount : &#8377; {receipt.data.totalAmount} </h2>
          </div>
        </Modal.Body>
        <Modal.Footer>
         
        </Modal.Footer>
      </Modal>
      <h3>You are using: {usingStation}</h3>
      <div className="col-lg-12 grid-margin stretch-card">
        <Card>
          <Card.Body>
            <h1 className="card-title">EV Charging Stations</h1>
            <div className="table-responsive">
              <Grid
                data={stations}
                columns={[
                  "Id",
                  "Name",
                  "areaName",
                  { 
                    name: 'isLocked',
                    formatter: (cell) => cell ? "Locked" : "UnLocked"
                  },
                  "ratePerMinute",
                  
                  { 
                    name: 'Actions',
                    columns: [{
                      name: '',
                      formatter: (cell, row) => {
                        return h(
                          "button",
                          {
                            id:`start${row.cells[0].data}`,
                            className:
                              "py-2 mb-4 px-4 border rounded-md btn text-white bg-secondary",
                            onClick: () => startFunction(row.cells[0].data,row.cells[1].data),
                          },
                          "Start"
                        );
                      },
                    }, {
                      name: '',
                      formatter: (cell, row) => {
                        return h(
                          "button",
                          {
                            className:
                              "py-2 mb-4 px-4 border rounded-md btn text-white bg-secondary",
                            onClick: () => stopFunction(row.cells[0].data),
                          },
                          "Stop"
                        );
                      },
                    }]
                  },
                ]}
                className={classNames}
                
              />
            </div>
          </Card.Body>
        </Card>
      </div>
    </>
  );
}