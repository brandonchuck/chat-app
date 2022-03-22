import React from "react";

const ChannelBar = ({ channels, setChannelName }) => {
  // return collapsable channel bar
  return (
    <div>
      <h3>Channel Bar</h3>
      {channels.map((channel, index) => {
        return (
          <button
            className="bg-green-200 px-1 mx-1"
            key={index}
            onClick={(e) => {
              setChannelName(e.target.textContent); // click on channel name to display channel messages in ChatWindow
              // setActive(true);
            }}
          >
            {channel.channelName}
          </button>
        );
      })}
    </div>
  );
};

export default ChannelBar;
