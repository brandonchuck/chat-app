import React, { useState } from "react";
import axios from "axios";

const ChannelBar = ({ channels, setChannels, setChannelName }) => {
  const [newChannel, setNewChannel] = useState("");

  const channel = { channelName: newChannel };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem("token");
    if (token !== null) {
      await axios.post("api/channel/create", channel, {
        headers: { Authorization: `Bearer ${token}` },
      });
      setChannels([...channels, newChannel]);
    }
  };

  console.log("I rendered bc of setChannels 2");

  return (
    <div>
      <h3>Channel Bar</h3>
      {channels.map((channel, index) => {
        return (
          <button
            className="bg-green-200 px-1 mx-1"
            key={index}
            onClick={(e) => {
              // e.preventDefault();
              setChannelName(e.target.textContent); // click on channel name to display channel messages in ChatWindow
              // setActive(true);
            }}
          >
            {channel.channelName}
          </button>
        );
      })}
      <input
        type="text"
        value={newChannel}
        onChange={(e) => setNewChannel(e.target.value)}
      />
      <button onSubmit={(e) => handleSubmit(e)} type="submit">
        Add Channel
      </button>
    </div>
  );
};

export default ChannelBar;
