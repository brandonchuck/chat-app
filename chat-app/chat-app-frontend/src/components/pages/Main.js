import React, { useState, useEffect } from "react";
import axios from "axios";
import ChannelBar from "../ChannelBar";
import ChatWindow from "../ChatWindow";
import MessageBar from "../MessageBar";

const Main = () => {
  const [channels, setChannels] = useState([]); // for ChannelBar
  const [channelMessages, setChannelMessages] = useState([]); // For ChatWindow
  const [channelName, setChannelName] = useState("anime"); // for channelBar

  // grab all messages from selected pre-selected channel
  useEffect(() => {
    getChannels();
    getChannelMessages();
  }, [channelName]); // how can I setChannelMessages without triggering a rerender every time

  const getChannels = async () => {
    const token = localStorage.getItem("token");
    if (token !== null) {
      const { data } = await axios
        .get("api/channel/channels", {
          headers: { Authorization: `Bearer ${token}` },
        })
        .catch((err) => console.log(err));
      setChannels(data);
    }
    console.log("I rendered bc of setChannels 1");
  };

  // get all messages from current channel
  const getChannelMessages = async () => {
    const token = localStorage.getItem("token");
    if (token !== null) {
      const { data } = await axios
        .get(`api/channel/${channelName}/messages`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .catch((err) => console.log(err));
      setChannelMessages(data);
    }
  };

  // return ChannelBar, ChatWindow, MessageBar
  return (
    <div>
      <div>
        <ChannelBar
          channels={channels}
          setChannels={setChannels}
          setChannelName={setChannelName}
        />
        {/* <DirectMessagesBar /> */}
      </div>

      <div>
        <ChatWindow
          channelName={channelName}
          channelMessages={channelMessages}
        />
      </div>
      <div>
        <MessageBar
          channelMessages={channelMessages}
          setChannelMessages={setChannelMessages}
          channelName={channelName}
        />
      </div>
    </div>
  );
};

export default Main;
